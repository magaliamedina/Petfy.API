using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petfy.Data.Models
{
    public class Owner
    {
        //public Owner()
        //{
        //    Pets = new List<Pet>();
        //}

        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public DateTime DateOfBirth { get; set  ; }

        public List<Pet> Pets { get; set; } = new List<Pet>();
    }
}
