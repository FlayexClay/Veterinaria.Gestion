using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Veterinaria.Gestion.Dto.Request.Mascota;
using Veterinaria.Gestion.Dto.Response.Mascota;
using Veterinaria.Gestion.Entidades;

namespace Veterinaria.Gestion.Servicio.Mappers
{
    public class MascotaMap : Profile
    {
        public MascotaMap() {
            CreateMap<MascotaRequest, Mascota>();
            CreateMap<Mascota, MascotaResponse>();
        }
    }
}
