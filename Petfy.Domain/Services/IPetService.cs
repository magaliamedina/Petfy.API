﻿using Petfy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petfy.Domain.Services
{
    //servicio que se encarga de hacer las llamadas al repositorio
    public interface IPetService
    {
        public List<Pet> GetAllPets(); //GetAll

        public List<Pet> GetByBreed(string Breed);
        public List<Pet> GetByOwnerId(int OwnerId);
        public List<Vaccine> GetAllVaccines(int PetId);

        public Pet GetById(int id); //GetById

        void AddPet(Pet pet); //AddPet

        public Pet EditPet(int Id, Pet updatedPet); //EditPet
        public bool DeletePet(int id);//DeletePet
    }
}