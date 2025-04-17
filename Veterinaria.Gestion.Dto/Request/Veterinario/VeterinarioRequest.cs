using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Gestion.Comun;

namespace Veterinaria.Gestion.Dto.Request.Veterinario
{
    public class VeterinarioRequest
    {
        [Required(ErrorMessage = Constantes.RequiredMessage)]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = Constantes.RequiredMessage)]
        public string Apellido { get; set; } = null!;

        [Required(ErrorMessage = Constantes.RequiredMessage)]
        public string Telefono { get; set; } = null!;

        [Required(ErrorMessage = Constantes.RequiredMessage)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = Constantes.RequiredMessage)]
        [Display(Name = "Especialidad")]
        public int IdEspecialidad { get; set; } 

        [Required(ErrorMessage = Constantes.RequiredMessage)]
        [Display(Name = "Licencia")]
        public string NumeroLicencia { get; set; } = null!;

        [Required(ErrorMessage = Constantes.RequiredMessage)]
        [Display(Name = "D.N.I")]
        public string DocumentoIdentidad { get; set; } = null!;
        public string Usuario { get; set; } = default!;

        [Required(ErrorMessage = Constantes.RequiredMessage)]
        public string Clave { get; set; } = default!;
        [Required(ErrorMessage = Constantes.RequiredMessage)]
        [Compare(nameof(Clave), ErrorMessage = "Las contraseñas no coinciden")]
        [Display(Name = "Confirmar Clave")]
        public string ConfirmarClave { get; set; } = default!;

    }
}
