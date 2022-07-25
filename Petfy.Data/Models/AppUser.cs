using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petfy.Data.Models
{
    //Se cambio el dbcontext a IdentityContext
    //Se tiene que agregar en el startup el identity para poder usar
    //el IdentityUser por default tiene un PK compuesto
    public class AppUser : IdentityUser<int> //int tipo de campo de la PK
    {
        //se comentan todos los campos porque ya trae el identity
        //public int ID { get; set; }
        //public string UserName { get; set; }
        //public byte[] PasswordHash { get; set; }
        //public byte[] PasswordSalt { get; set; } este no tiene el identity
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
