using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Gestion.Dto.Request.Cliente
{
    public class BusquedaClienteRequest : PaginacionRequest
    {
        public string? Nombre { get; set; }
        public string? DocumentoIdentidad { get; set; }
    }
}
