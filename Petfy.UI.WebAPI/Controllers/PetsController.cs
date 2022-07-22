using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Petfy.Data;
using Petfy.Data.Models;
using Petfy.Domain.DTO;
using Petfy.Domain.Services;
using Petfy.UI.WebAPI.DTO;

namespace Petfy.UI.WebAPI.Controllers
{
    //lo de preguntar si el pets == null deberia hacer el servicio o el contexto
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petservice;

        public PetsController(IPetService petService)
        {
            _petservice = petService;
        }

        // GET: api/Pets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets()
        {
            var pets= _petservice.GetAllPets();
            if (pets == null)
            {
                return NotFound();
            }
            return pets;
        }

        //los que reciben string no se pone el tipo de dato al lado
        // GET: api/Pets/bullterrier
        [HttpGet("{breed}")]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets(string breed)
        {
            var pets = _petservice.GetByBreed(breed);
            if (pets == null)
            {
                return NotFound();
            }
            return pets;
        }

        //// GET: api/Pets/Breed/Bulterrier/OwnerId/3
        //[HttpGet("/breed/{breed}/ownerid/{ownerid}:int")]
        //public async Task<ActionResult<IEnumerable<Pet>>> GetPetss(string breed, int ownerId)
        //{
        //    var pets = _petservice.GetByBreed(breed);
        //    if (pets == null)
        //    {
        //        return NotFound();
        //    }
        //    return pets;
        //}

        // GET: api/Pets/3/vaccines
        [HttpGet("{id:int}/vaccines")]
        public async Task<ActionResult<IEnumerable<Vaccine>>> GetPetsVaccines(int id)
        {
            var vaccines = _petservice.GetAllVaccines(id);
            if (vaccines == null)
            {
                return NotFound();
            }
            return vaccines;
        }

        // GET: api/Pets/ownerid/5
        [HttpGet("ownerid/{ownerId:int}")]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPetsByOwnerId(int ownerId)
        {
            var pets = _petservice.GetByOwnerId(ownerId);
            if (pets == null)
            {
                return NotFound();
            }
            return pets;
        }

        //el nombre del http tiene que ser igual que el del parametro
        // GET: api/Pets/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pet>> GetPet(int id)
        {
            var pets = _petservice.GetAllPets();
            if (pets == null)
            {
                return NotFound();
            }
            var pet = _petservice.GetById(id);

            if (pet == null)
            {
                return NotFound();
            }

            return pet;
        }

        // PUT: api/Pets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPet(int id, PetDTO pet)
        {
            //if (id != pet.ID)
            //{
            //    return BadRequest();
            //}

            // _petservice.Entry(pet).State = EntityState.Modified;

            try
            {
                _petservice.EditPet(id, pet);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return NoContent();
        }

        // POST: api/Pets
        [HttpPost]
        public async Task<ActionResult<Pet>> PostPet(PetDTO pet)
        {
            var pets = _petservice.GetAllPets();
            if (pets == null)
            {
                return Problem("Entity set 'PetfyDbContext.Pets'  is null.");
            }
            try
            {
                _petservice.AddPet(pet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //return Ok(pet);
            return CreatedAtAction("GetPet", new { id = pet.ID }, pet);
        }

        // DELETE: api/Pets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            var pets = _petservice.GetAllPets();
            if (pets == null)
            {
                return NotFound();
            }
            try
            {
                var deleteFlag = _petservice.DeletePet(id);
                if (!deleteFlag)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return NoContent();
        }

        //private bool PetExists(int id)
        //{
        //    return (_petservice.Pets?.Any(e => e.ID == id)).GetValueOrDefault();
        //}
    }
}
