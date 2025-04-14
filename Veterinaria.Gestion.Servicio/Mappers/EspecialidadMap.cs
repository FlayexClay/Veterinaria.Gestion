using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Veterinaria.Gestion.Dto.Request.Especialidad;
using Veterinaria.Gestion.Dto.Response.Especialidad;
using Veterinaria.Gestion.Entidades;

namespace Veterinaria.Gestion.Servicio.Mappers
{
    public class EspecialidadMap : Profile
    {
        public EspecialidadMap()
        {
            CreateMap<EspecialidadRequest, Especialidad>();
            CreateMap<Especialidad, EspecialidadResponse>();
        }
    }
}
