using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petfy.Data.Models
{
    public class PetVaccine
    {
        public int PetID { get; set; }

        public int VaccineID { get; set; }

        public Pet Pet { get; set; }

        public Vaccine Vaccine { get; set; }

        public DateTime DateApplied { get; set; }
    }
}
