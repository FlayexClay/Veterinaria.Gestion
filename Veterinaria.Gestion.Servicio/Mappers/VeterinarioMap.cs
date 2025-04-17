using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Veterinaria.Gestion.Dto.Request.Veterinario;
using Veterinaria.Gestion.Dto.Response.Veterinario;
using Veterinaria.Gestion.Entidades;

namespace Veterinaria.Gestion.Servicio.Mappers
{
    public class VeterinarioMap : Profile
    {
        public VeterinarioMap() { 
            
            CreateMap<VeterinarioRequest, Veterinario>();
            CreateMap<Veterinario, VeterinarioResponse>();
        }

    }
}
