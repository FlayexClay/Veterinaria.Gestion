using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Gestion.Dto.Response.Cliente
{
    public class ListaClienteResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public string? Email { get; set; }

        public string? Direccion { get; set; }

        public string? DocumentoIdentidad { get; set; }
    }
}
