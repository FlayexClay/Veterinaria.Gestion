using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Veterinaria.Gestion.AccesoDatos.Contexto;
using Veterinaria.Gestion.Entidades;
using Veterinaria.Gestion.Repositorios.Interfaces;

namespace Veterinaria.Gestion.Repositorios.Implementaciones
{
    public class RepositorioBase<TEntidad>: IRepositorioBase<TEntidad> where TEntidad : EntidadBase
    {
        private readonly BdVeterinarioContext _contexto;

        public RepositorioBase(BdVeterinarioContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<ICollection<TEntidad>> ListAsync()
        {
            return await _contexto.Set<TEntidad>()
                .Where(p => p.Activo == true)
                .ToListAsync();
        }

        public async Task<ICollection<TResultado>> ListAsync<TResultado>
        (   Expression<Func<TEntidad, bool>> predicado, 
            Expression<Func<TEntidad, TResultado>> selector
        )
        { 
            return await _contexto.Set<TEntidad>()
                .Where(predicado)
                .Select(selector)
                .ToListAsync();
        }

        public async Task<(ICollection<TResultado> Coleccion, int TotalRegistros )> ListAsync<TResultado>
      (
          Expression<Func<TEntidad, bool>> predicado,
          Expression<Func<TEntidad, TResultado>> selector,
          int pagina = 1, int filas = 10
      )
        {
            var resultado = await _contexto.Set<TEntidad>()
                .Where(predicado)
                .OrderBy(p => p.Id)
                .Skip((pagina -1) * filas)
                .Take(filas)
                .Select(selector)
                .ToListAsync();

            var totalRegistros = await _contexto.Set<TEntidad>()
                                         .Where(predicado)
                                        .CountAsync();

            return (resultado, totalRegistros);
        }


        public async Task<TEntidad> AddAsync(TEntidad entidad)
        { 
            var resultado = await _contexto.Set<TEntidad>().AddAsync(entidad);
            await _contexto.SaveChangesAsync();
            return resultado.Entity;
        }

        public async Task<TEntidad?> FindAsync(int id)
        {
            return await _contexto.Set<TEntidad>().FirstOrDefaultAsync(p => p.Activo == true && p.Id == id);
        }

        public async Task UpdateAsync()
        { 
            await _contexto.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _contexto.Set<TEntidad>()
                  .Where(p => p.Id == id)
                  .ExecuteUpdateAsync(p => 
                  p.SetProperty(p => p.Activo, false));
        }
    }
}
