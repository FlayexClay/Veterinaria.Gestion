using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Gestion.Comun;

namespace Veterinaria.Gestion.Dto.Request.Login
{
    public class LoginRequest
    {
        [Required(ErrorMessage = Constantes.RequiredMessage)]
        public string Usuario { get; set; } = default!;
        [Required(ErrorMessage = Constantes.RequiredMessage)]
        public string Clave { get; set; } = default!;
    }
}
