using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Gestion.Entidades;

namespace Veterinaria.Gestion.Repositorios.Interfaces
{
    public interface IClienteRepositorio : IRepositorioBase<Cliente>
    {
        Task<List<Cliente>> ListarDetalleByCliente(int id);

        Task Registrar(Cliente cliente, string usuario, string clave);
    }


}
