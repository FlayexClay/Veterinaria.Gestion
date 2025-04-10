using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Gestion.Comun;

namespace Veterinaria.Gestion.Dto.Response.Cliente
{
    public class ClienteResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string DocumentoIdentidad { get; set; } = null!;
    }
}
