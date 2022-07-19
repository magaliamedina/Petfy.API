using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Petfy.Data;
using Petfy.Data.Models;
using Petfy.Domain.Services;
using Petfy.UI.WebAPI.DTO;
using System.Security.Cryptography;
using System.Text;

namespace Petfy.UI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly PetfyDbContext _context;
        public readonly ITokenService _tokenService;

        public AccountController(PetfyDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        //Post
        //login
        [HttpPost("login")]
        public ActionResult<UserDTO> Login(LoginDTO login)
        {
            var user = _context.Users.SingleOrDefault(x => x.UserName == login.Username);

            if (user == null) return Unauthorized("Username or password incorrect");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Username or password incorrect");
            }

            var token = _tokenService.CreateToken(user);

            var userDto = new UserDTO()
            {
                UserName = login.Username,
                Token = token
            };

            return Ok(userDto);
        }

        //Post
        //register
        [HttpPost("register")]
        public ActionResult<UserDTO> Register(RegisterDTO user)
        {
            //if (UserExists(user.Username)) return BadRequest("User already taken");

            using var hmac = new HMACSHA512();

            var newUser = new User()
            {
                UserName = user.Username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            var token = _tokenService.CreateToken(newUser);

            var userDto = new UserDTO()
            {
                UserName = user.Username,
                Token = token
            };

            return Ok(userDto);
        }

        private bool UserExists(string username)
        {
            return _context.Users.Any(u => u.UserName == username);
        }
    }
}
