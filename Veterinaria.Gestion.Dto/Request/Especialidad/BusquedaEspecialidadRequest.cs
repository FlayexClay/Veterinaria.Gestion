using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Gestion.Dto.Request.Especialidad
{
    public class BusquedaEspecialidadRequest : PaginacionRequest
    {
        public string? Nombre { get; set; }
    }
}
