using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Gestion.Dto.Response
{
    public class PaginacionResponse<T> : ResponseBase
    {
        public ICollection<T> Data { get; set; } = new List<T>();
        public int TotalFilas { get; set; }  

        public int TotalPaginas { get; set; } 
    }
}
