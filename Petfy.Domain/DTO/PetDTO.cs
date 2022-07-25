using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petfy.Domain.DTO
{
    public class PetDTO
    {
        //public int ID { get; set; }
        public string Name { get; set; }
        public int? PetNumber { get; set; }
        public string Description { get; set; }
        public string Breed { get; set; }
        public string MainPhotoUrl { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Type { get; set; }
        public int OwnerID { get; set; }
        public OwnerDTO Owner { get; set; }
        public List<PhotoDTO> Photos { get; set; }
    }
}
