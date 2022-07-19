using Microsoft.EntityFrameworkCore;
using Petfy.Data;
using Petfy.Data.Models;
using Petfy.Data.Repositories;

using (var context = new PetfyDbContext())
{
    /////Para asegurarnos que la base de datos está creada
    //context.Database.EnsureCreated();

    /////Para utilizar migrations de entity.
    /////No es necesario correrlo todas las veces
    //context.Database.Migrate();

    /////Si queremos usar el repository en lugar de todo el context
    ////var repository = new PetRepository(context);

    //Console.WriteLine("Before Insert");

    /////Obtiene la lista de mascotas del contexto. Con Include se pueden traer los objetos relacionados, en este caso, owner
    //var pets = context.Pets.Include(x => x.Owner).ToList();

    /////Obtiene la lista de vacunas del contexto
    ////var vaccines = context.Vaccines.ToList();

    /////Recorre la lista de mascotas
    //foreach (var pet in pets)
    //{
    //    ///Obtiene el owner de una mascota, usando el Id guardado en cada objeto Pet. NO es necesario si al traer la lista se usa Include.
    //    ///Para obtener un objeto en particular usando el Id, usamos Find.
    //    var owner = context.Owners.Find(pet.OwnerID);
    //    //Console.WriteLine(owner.Name);
    //    Console.WriteLine($"Pet Name: {pet.Name} | Owner Name: {pet.Owner.Name}");

    //    ///Asigna una lista de vacunas a una mascota.
    //    //pet.Vaccines = vaccines;
    //}

    /////Obtiene la lista de dueños de mascotas del contexto. Con Include se pueden traer los objetos relacionados, en este caso, pets
    //var owners = context.Owners.Include(x => x.Pets).ToList();

    /////Recorre la lista de dueños
    //foreach (var owner in owners)
    //{
    //    Console.WriteLine(owner.ID + " " + owner.Name);
    //    ///Recorre la lista de mascotas de cada dueño
    //    foreach (var pet in owner.Pets)
    //    {
    //        Console.WriteLine($"Pet Name: {pet.Name} Breed: {pet.Breed}");
    //    }
    //}

    //var maxPetNumber = context.Pets.Max(x => x.PetNumber);

    ///Se crea un nuevo dueño
    //var newOwner = new Owner()
    //{
    //    Name = "Fernando",
    //    Address = "",
    //    City = "",
    //    DateOfBirth = DateTime.Now,
    //};

    // Se crea una nueva mascota
    //var newPet = new Pet()
    //{
    //    Name = "Gato",
    //    Breed = "nose",
    //    DateOfBirth = DateTime.Today,
    //    Description = "My cat new",
    //    Type = "Cat",
    //};

    ///Diferentes formas de añadir las relaciones entre Pet y Owner
    //newOwner.Pets.Add(newPet);
    //newPet.Owner = newOwner;
    //newPet.OwnerID = 2;

    ///Se añaden los nuevos objetos creados al contexto, usando Add
    ///Si no se añaden, no se guardan en la base de datos
    //context.Pets.Add(newPet);
    //context.Owners.Add(newOwner);

    ///Se trae una mascota en particular usando el Id
    //var upet = context.Pets.Find(3);
    ///Y se la actualiza. La actualización se guarda más adelante con el SaveChanges
    //upet.Name = "Otro gato";

    ///Se crean dos nuevas vacunas y se las añaden en una lista temporal, que luego será utilizada para guardar las vacunas al mismo tiempo
    //var vaccines = new List<Vaccine>()
    //{
    //    new Vaccine()
    //    {
    //        Name = "Vacuna 1",
    //        Lab = "Lab1"
    //    },
    //    new Vaccine()
    //    {
    //        Name = "Vacuna 2",
    //        Lab = "Lab1"
    //    }
    //};

    //var specialPets = context.Pets.Where(x => x.Type == "Cat").ToList();

    //var newVaccine = new Vaccine()
    //{
    //    Name = "Vacuna especial",
    //    Lab = "Otro Lab",
    //    Pets = specialPets
    //};

    ///Se añade una nueva vacuna creada
    //context.Vaccines.Add(newVaccine);

    ///Se ejecuta para guardar todos los objetos creados y también los que fueron actualizados
    ///Si no se llama a SaveChanges, no se guarda nada
    //context.SaveChanges();


    //var pets = context.Pets.ToList();

    //newPet.PetVaccines.Add(new PetVaccine()
    //{
    //    VaccineID = 1,
    //    DateApplied = DateTime.Today,
    //});

    //repository.AddPet(newPet);

    //Console.WriteLine("After Insert");

    //var petsUpdated = repository.GetAllPets();

    //foreach (var pet in petsUpdated)
    //{
    //    Console.WriteLine($"Name: {pet.Name} Breed: {pet.Breed}");

    //    //if (pet.ID == 1)
    //    //{
    //    //    context.Pets.Remove(pet);
    //    //    context.SaveChanges();
    //    //}
    //}
}
