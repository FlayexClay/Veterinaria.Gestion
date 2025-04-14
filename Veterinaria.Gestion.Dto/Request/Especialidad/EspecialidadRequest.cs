using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Gestion.Comun;

namespace Veterinaria.Gestion.Dto.Request.Especialidad
{
    public class EspecialidadRequest
    {
        [Required(ErrorMessage = Constantes.RequiredMessage)]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = Constantes.RequiredMessage)]
        public string Descripcion { get; set; } = null!;
    }
}
