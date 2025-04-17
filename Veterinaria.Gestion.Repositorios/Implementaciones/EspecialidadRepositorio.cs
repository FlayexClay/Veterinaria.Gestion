using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Veterinaria.Gestion.AccesoDatos.Contexto;
using Veterinaria.Gestion.Entidades;
using Veterinaria.Gestion.Repositorios.Interfaces;

namespace Veterinaria.Gestion.Repositorios.Implementaciones
{
    public class EspecialidadRepositorio : RepositorioBase<Especialidad>, IEspecialidadRepositorio
    {
        private readonly BdVeterinarioContext _contexto;

        public EspecialidadRepositorio(BdVeterinarioContext contexto) : base(contexto)
        {
           _contexto = contexto;
        }


        public async Task<List<Especialidad>> ListarDetalleByEspecialidad(int id)
        {
            if (id == 0)
            {
                return await _contexto.Especialidads
                    .ToListAsync();
            }
            return await _contexto.Especialidads
                  .Where(c => c.Id == id)
                 .AsNoTracking()
                .ToListAsync();
        }

    }
}
