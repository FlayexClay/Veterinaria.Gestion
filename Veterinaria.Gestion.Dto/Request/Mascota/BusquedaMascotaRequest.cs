using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Gestion.Dto.Request.Mascota
{
    public class BusquedaMascotaRequest : PaginacionRequest
    {
        public string? Nombre { get; set; }
    }
}
