using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        public readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountController( ITokenService tokenService,
            SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        //Post
        //login
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO login)
        {
            var user = _userManager.Users.SingleOrDefault(x => x.UserName == login.Username);

            if (user == null) return Unauthorized("Username or password incorrect");

            //using var hmac = new HMACSHA512(user.PasswordSalt);

            //var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));

            //for (int i = 0; i < computedHash.Length; i++)
            //{
            //    if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Username or password incorrect");
            //}

            //el 3er parametro booleano es bloquear al usuario si falla el intento 
            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);

            if (result.Succeeded) return Unauthorized();

            var token = _tokenService.CreateToken(user); //crea el token

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
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO user)
        {
            if (UserExists(user.Username)) return BadRequest("User already taken");

            //using var hmac = new HMACSHA512();

            var newUser = new AppUser()
            {
                UserName = user.Username,
                //PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password)),
                //PasswordSalt = hmac.Key
            };

            //await es para esperar a que termine de ejecutarse el metodo sin que se bloquee (se vuelve asyncronico el metodo)
            //el userManager agrega el usuario y guarda cambios
            var result = await _userManager.CreateAsync(newUser, user.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

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
            return _userManager.Users.Any(u => u.UserName == username);
        }
    }
}
