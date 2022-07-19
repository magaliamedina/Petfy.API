using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Petfy.Data;
using Petfy.Data.Models;

namespace Petfy.UI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class OwnersController : ControllerBase
    {
        private readonly PetfyDbContext _context;

        public OwnersController(PetfyDbContext context)
        {
            _context = context;
        }

        // GET: api/Pets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Owner>>> GetOwners()
        {
            if (_context.Owners == null)
            {
                return NotFound();
            }
            return await _context.Owners.ToListAsync();
        }

        // GET: api/Owners/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Owner>> GetOwner(int id)
        {
            if (_context.Owners == null)
            {
                return NotFound();
            }
            var owner = await _context.Owners.FindAsync(id);

            if (owner == null)
            {
                return NotFound();
            }

            return owner;
        }

        // PUT: api/Owners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwner(int id, Owner owner)
        {
            if (id != owner.ID)
            {
                return BadRequest();
            }

            _context.Entry(owner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!OwnerExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw ex;
                }
            }

            return NoContent();
        }

        // POST: api/Owners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pet>> PostOwners(Owner owner)
        {
            if (_context.Owners == null)
            {
                return Problem("Entity set 'PetfyDbContext.Owners'  is null.");
            }
            _context.Owners.Add(owner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOwner", new { id = owner.ID }, owner);
        }

        // DELETE: api/Owners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            if (_context.Owners == null)
            {
                return NotFound();
            }
            var owner = await _context.Owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }

            _context.Owners.Remove(owner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OwnerExist(int id)
        {
            return (_context.Owners?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
