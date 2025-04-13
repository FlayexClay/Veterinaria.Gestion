using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Veterinaria.Gestion.AccesoDatos.Seguridad;

namespace Veterinaria.Gestion.AccesoDatos.Contexto
{
    public class BdSeguridadContext : IdentityDbContext<SeguridadEntity>
    {
 
        public BdSeguridadContext(DbContextOptions<BdSeguridadContext> options): base(options) 
        {
            
            
        }
       
    }
}
