using AutoMapper;
using Petfy.Data.Models;
using Petfy.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petfy.Domain.Extensions
{
    //se debe incluir en el startup para poder usarlo como servicio
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            //Configurar los mapas
            CreateMap<User, UserDTO>();
            //origen, destino
            CreateMap<Pet, PetDTO>()
                .ForMember(
                dest => dest.MainPhotoUrl, 
                opt => opt.MapFrom(
                    p => p.Photos.Where(p => p.IsMain).FirstOrDefault().URL)); 
        }
    }
}
