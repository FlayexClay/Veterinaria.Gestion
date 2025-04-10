using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Gestion.Comun;

namespace Veterinaria.Gestion.Dto.Response.Mascota
{
    public class MascotaResponse
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }

        public string Nombre { get; set; } = null!;

        public string Especie { get; set; } = null!;

        public string? Raza { get; set; }

        public DateOnly? FechaNacimiento { get; set; }

        public decimal? Peso { get; set; }

        public string? Alergias { get; set; }
    }
}
