using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Veterinaria.Gestion.AccesoDatos.Seguridad
{
    public class SeedData
    {
        public static async Task Inicializar(IServiceProvider serviceProvider)
        {
            var userService = serviceProvider.GetRequiredService<UserManager<SeguridadEntity>>();
            var RoleService = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roles = { "Administrador", "Cliente" , "Veterinario"};

            foreach (var role in roles)
            {
                if (!await RoleService.RoleExistsAsync(role))
                {
                    await RoleService.CreateAsync(new IdentityRole(role));
                }
            }

            var admin = new SeguridadEntity()
            {
                IdUsuario = 0,
                NombreCompleto = "Administrador del sistema",
                Email = "admin@gmail.com",
                UserName = "admin"
            };

            await userService.CreateAsync(admin, "Password2025#");
            await userService.AddToRoleAsync(admin, "Administrador");
        }
    }
}
