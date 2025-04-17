using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Veterinaria.Gestion.AccesoDatos.Contexto;
using Veterinaria.Gestion.AccesoDatos.Seguridad;
using Veterinaria.Gestion.Entidades;
using Veterinaria.Gestion.Repositorios.Interfaces;

namespace Veterinaria.Gestion.Repositorios.Implementaciones
{
    public class VeterinarioRepositorio : RepositorioBase<Veterinario> , IVeterinarioRepositorio
    {
        private readonly BdVeterinarioContext _contexto;
        private UserManager<SeguridadEntity> _userManager;

        public VeterinarioRepositorio(BdVeterinarioContext contexto, UserManager<SeguridadEntity> userManager) : base(contexto)
        {
            _contexto = contexto;
            _userManager = userManager;
        }


        public async Task<List<Veterinario>> ListaDetalleByVeterinario(int id)
        {
            if (id == 0)
            {
                return await _contexto.Veterinarios
                    .ToListAsync();
            }

            return await _contexto.Veterinarios
                .Where(c => c.Id == id)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task Registrar(Veterinario veterinario, string usuario, string clave)
        {
            var nuevo = await _contexto.Veterinarios.AddAsync(veterinario);
            await _contexto.SaveChangesAsync();

            var nuevoUsuario = new SeguridadEntity()
            {
                IdUsuario = nuevo.Entity.Id,
                NombreCompleto = veterinario.Nombre,
                Email = veterinario.Email,
                UserName = usuario

            };

            await _userManager.CreateAsync(nuevoUsuario, clave);
            await _userManager.AddToRoleAsync(nuevoUsuario, "Veterinario");
        }  


    }
}
