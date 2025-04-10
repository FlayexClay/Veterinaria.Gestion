using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Gestion.Comun;

namespace Veterinaria.Gestion.Dto.Request.Mascota
{
    public class MascotaRequest
    {
        [Required(ErrorMessage = Constantes.RequiredMessage)]
        [DeniedValues(0, ErrorMessage = Constantes.RequiredMessage)]
        [Display(Name = "Dueño")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = Constantes.RequiredMessage)]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = Constantes.RequiredMessage)]
        public string Especie { get; set; } = null!;

        [Required(ErrorMessage = Constantes.RequiredMessage)]
        public string? Raza { get; set; }

        [Required(ErrorMessage = Constantes.RequiredMessage)]
        [Display(Name = "Fecha Nacimiento")]
        public DateOnly? FechaNacimiento { get; set; }

        [Required(ErrorMessage = Constantes.RequiredMessage)]
        public decimal? Peso { get; set; }

        [Required(ErrorMessage = Constantes.RequiredMessage)]
        public string? Alergias { get; set; }
    }
}
