using Petfy.Data.Models;
using Petfy.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petfy.Domain.Services
{
    //servicio que se encarga de hacer las llamadas al repositorio
    //el servicio siempre se hace la inyeccion de dependencia en el program.cs o startup.cs en este caso
    public interface IPetService
    {
        //cambiar a todos que devuelva un petDTO
        public IEnumerable<PetDTO> GetAllPets(); //GetAll

        public List<Pet> GetByBreed(string Breed);
        public List<Pet> GetByOwnerId(int OwnerId);
        public List<Vaccine> GetAllVaccines(int PetId);

        public PetDTO GetById(int id); //GetById

        void AddPet(PetDTO pet); //AddPet

        public Pet EditPet(int Id, PetDTO updatedPet); //EditPet
        public bool DeletePet(int id);//DeletePet
    }
}
