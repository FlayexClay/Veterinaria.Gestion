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
    public class ClienteRepositorio : RepositorioBase<Cliente>, IClienteRepositorio
    {
        
        private readonly BdVeterinarioContext _contexto;
        private UserManager<SeguridadEntity> _userManager;

        public ClienteRepositorio(BdVeterinarioContext contexto, UserManager<SeguridadEntity> userManager) : base(contexto)
        {
            _contexto = contexto;
            _userManager = userManager;
        }

        public async Task<List<Cliente>> ListarDetalleByCliente(int id)
        {
            if ( id == 0)
            {
                return await _contexto.Clientes
                    .ToListAsync();
            }
            return await _contexto.Clientes
                  .Where(c => c.Id == id)
                 .AsNoTracking()
                .ToListAsync();
        }


        public async Task Registrar(Cliente cliente, string usuario, string clave)
        {
            var nuevo = await _contexto.Clientes.AddAsync(cliente);
            await _contexto.SaveChangesAsync();

            var nuevoUsuario = new SeguridadEntity()
            {
                IdUsuario = nuevo.Entity.Id,
                NombreCompleto = cliente.Nombre,
                Email = cliente.Email,
                UserName = usuario

            };

            await _userManager.CreateAsync(nuevoUsuario, clave);
            await _userManager.AddToRoleAsync(nuevoUsuario, "Cliente");
        }

    }
}
