using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Gestion.Entidades;
using Veterinaria.Gestion.Repositorios.Implementaciones;

namespace Veterinaria.Gestion.Repositorios.Interfaces
{
    public interface IVeterinarioRepositorio : IRepositorioBase<Veterinario> 
    {
        Task<List<Veterinario>> ListaDetalleByVeterinario(int id);

        Task Registrar(Veterinario veterinario, string usuario, string clave);


    }
}
