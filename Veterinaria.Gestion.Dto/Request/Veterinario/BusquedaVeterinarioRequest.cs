using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Gestion.Dto.Request.Veterinario
{
    public class BusquedaVeterinarioRequest : PaginacionRequest
    {
        public string? Nombre { get; set; }

        public string? NumeroLicencia { get; set; }
    }
}
