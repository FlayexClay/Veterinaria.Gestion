using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Gestion.Dto.Response.Login
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public string Email { get; set; } = default!;
        public string NombreCompleto { get; set; } = default!;
        public string Rol { get; set; } = default!;
    }
}
