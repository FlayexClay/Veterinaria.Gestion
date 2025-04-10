using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Veterinaria.Gestion.Dto.Request.Cliente;
using Veterinaria.Gestion.Dto.Response.Cliente;
using Veterinaria.Gestion.Entidades;

namespace Veterinaria.Gestion.Servicio.Mappers
{
    public class ClienteMap : Profile
    {
        public ClienteMap() {
            CreateMap<ClienteRequest, Cliente>();
            CreateMap<Cliente, ClienteResponse>();
        }
    }
}
