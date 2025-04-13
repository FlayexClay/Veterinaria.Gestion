using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Veterinaria.Gestion.AccesoDatos.Seguridad
{
    public class SeguridadEntity : IdentityUser
    {
        public int IdUsuario { get; set; } 
        public string NombreCompleto { get; set; } = default!;
    }
}
