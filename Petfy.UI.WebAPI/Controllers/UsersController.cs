using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Petfy.Data;
using Petfy.Data.Models;

namespace Petfy.UI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsersController : ControllerBase
    {
        private readonly PetfyDbContext _context;

        public UsersController(PetfyDbContext context)
        {
            _context = context;
        }

        //Get
        //GetUsers
        [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            return Ok(_context.Users.ToList());
        }

        //Get
        //GetUserById
        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUser(int id)
        {
            return Ok(_context.Users.Find(id));
        }
    }
}
