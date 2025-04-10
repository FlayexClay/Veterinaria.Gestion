using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Gestion.Dto.Request
{
    public class PaginacionRequest
    {
        public int Pagina { get; set; } = 1;
        
        public int Filas { get; set; } = 10;
    }
}
