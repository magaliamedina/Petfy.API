using Microsoft.EntityFrameworkCore;
using Petfy.Data.Models;

namespace Petfy.Data.Repositories
{
    //En el repository se hace solo el CRUD
    //Manejan los datos a nivel de BD
    public class PetRepository : IPetRepository
    {
        private readonly PetfyDbContext _context;

        public PetRepository(PetfyDbContext context)
        {
            _context=context;
        }

        public List<Pet> GetAllPets()
        {
            return _context.Pets.Include(p =>  p.Vaccines)
                .Include(p => p.Owner).ToList();
        }

        //public List<Pet> GetByBreed(string Breed)
        //{
        //    return context.Pets.Where(p => p.Breed == Breed).ToList();
        //}
        //public List<Pet> GetByOwnerId(int OwnerId)
        //{
        //    return context.Pets.Where(p => p.OwnerID == OwnerId).ToList();
        //}

        //public List<Vaccine> GetAllVaccines(int PetId)
        //{
        //    try
        //    {
        //        return context.Pets.Include(p => p.Vaccines).Where(p => p.ID == PetId).FirstOrDefault()?.Vaccines?.ToList();
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }            
        //}

        public Pet GetById(int Id)
        {
            return _context.Pets.Find(Id);
        }

        public void AddPet(Pet pet)
        {
            if (pet != null)
            {
                try
                {
                    _context.Pets.Add(pet);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                
            }
        }

        public Pet EditPet(int Id,Pet updatedPet)
        {
            var oldPet = _context.Pets.Find(Id);
            if(oldPet!= null && oldPet.ID == updatedPet.ID)
            {
                //el id no se modifica
                oldPet.Name = updatedPet.Name;
                oldPet.Description = updatedPet.Description;
                //no se cambia desde el punto de vista de negocio
                //oldPet.Breed = updatedPet.Breed;
                //oldPet.Type = updatedPet.Type;
                //oldPet.Vaccines = updatedPet.Vaccines;
                oldPet.DateOfBirth = updatedPet.DateOfBirth;
                oldPet.PetNumber = updatedPet.PetNumber;

                try
                {
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }

                return oldPet;
                
            }
            return updatedPet;
        }
        public bool DeletePet(int id)
        {
            var pet = _context.Pets.Find(id);
            if(pet != null)
            {
                try
                {
                    _context.Pets.Remove(pet);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                return true;
            }
            return false;
        }

    }
}
