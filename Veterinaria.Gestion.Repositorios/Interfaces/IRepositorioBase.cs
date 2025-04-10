using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Gestion.Entidades;

namespace Veterinaria.Gestion.Repositorios.Interfaces
{
    public interface IRepositorioBase<TEntidad> where TEntidad : EntidadBase 
    {
        Task<ICollection<TEntidad>> ListAsync();

        Task<ICollection<TResultado>> ListAsync<TResultado>
        (Expression<Func<TEntidad, bool>> predicado,
            Expression<Func<TEntidad, TResultado>> selector
        );

        Task<(ICollection<TResultado> Coleccion, int TotalRegistros)> ListAsync<TResultado>
        (
            Expression<Func<TEntidad, bool>> predicado,
            Expression<Func<TEntidad, TResultado>> selector,
            int pagina = 1, int filas = 10
        );
        Task<TEntidad> AddAsync(TEntidad entidad);

        Task<TEntidad?> FindAsync(int id);

        Task UpdateAsync();

        Task DeleteAsync(int id);
    }
}
