using Petfy.Data.Models;
using Petfy.Data.Repositories;
using Petfy.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petfy.Domain.Services
{
    //aca se hace: 1. validaciones 2. capturar errores y retornarlos 3. cambios a nivel de lo que el usuario va a ver  (ej que solo se actualice un solo campo en el edit)
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
           _petRepository = petRepository;
        }
        public List<Pet> GetAllPets()
        {
            return _petRepository.GetAllPets();
        }

        public List<Pet> GetByBreed(string Breed)
        {
            return _petRepository.GetAllPets().Where(p => p.Breed == Breed).ToList();
        }
        public List<Pet> GetByOwnerId(int OwnerId)
        {
            return _petRepository.GetAllPets().Where(p => p.OwnerID == OwnerId).ToList();
        }
        public List<Vaccine> GetAllVaccines(int PetId)
        {
            try
            {
               return _petRepository.GetAllPets().Where(p => p.ID == PetId).FirstOrDefault()?.Vaccines?.ToList();
            }
            catch(Exception ex)
            {
               throw ex;
            }  
        }
        public Pet GetById(int id)
        {
            return _petRepository.GetById(id);
        }

        public void AddPet(PetDTO petDTO)
        {
            try
            {
                Pet pet = new Pet()
                {
                    Name = petDTO.Name,
                    Breed = petDTO.Breed,
                    Description = petDTO.Description,
                    PetNumber = petDTO.PetNumber,
                    DateOfBirth = petDTO.DateOfBirth,
                    Type = petDTO.Type,
                    OwnerID=petDTO.OwnerID
                };
                _petRepository.AddPet(pet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Pet EditPet(int Id, Pet updatedPet)
        {
            try
            {
                return _petRepository.EditPet(Id, updatedPet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool DeletePet(int id)
        {
            try
            {
                return _petRepository.DeletePet(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
