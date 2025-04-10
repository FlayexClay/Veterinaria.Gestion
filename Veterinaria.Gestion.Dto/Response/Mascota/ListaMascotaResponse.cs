using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Gestion.Dto.Response.Mascota
{
    public class ListaMascotaResponse
    {
        public int Id { get; set; }
        public string Dueño { get; set; } = default!;

        public string Nombre { get; set; } = null!;

        public string Especie { get; set; } = null!;

        public string? Raza { get; set; }

        public DateOnly? FechaNacimiento { get; set; }

        public decimal? Peso { get; set; }

        public string? Alergias { get; set; }
    }
}
