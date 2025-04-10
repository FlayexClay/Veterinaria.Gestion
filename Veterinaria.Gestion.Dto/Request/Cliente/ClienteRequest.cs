using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Gestion.Comun;

namespace Veterinaria.Gestion.Dto.Request.Cliente
{
    public class ClienteRequest
    {
        [Required(ErrorMessage = Constantes.RequiredMessage)]
        public string Nombre { get; set; } = null!;

        
        [Required(ErrorMessage = Constantes.RequiredMessage)]
        [Display(Name = "Apellidos")]
        public string Apellido { get; set; } = null!;

        [Required(ErrorMessage = Constantes.RequiredMessage)]
        public string Telefono { get; set; } = null!;

        [Required(ErrorMessage = Constantes.RequiredMessage)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = Constantes.RequiredMessage)]
        public string Direccion { get; set; } = null!;

        [Required(ErrorMessage = Constantes.RequiredMessage)]
        [Display(Name = "D.N.I")]
        public string DocumentoIdentidad { get; set; } = null!;
    }
}
