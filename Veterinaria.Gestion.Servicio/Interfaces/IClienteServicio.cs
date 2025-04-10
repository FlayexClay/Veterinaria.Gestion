using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Gestion.Dto.Request.Cliente;
using Veterinaria.Gestion.Dto.Response;
using Veterinaria.Gestion.Dto.Response.Cliente;

namespace Veterinaria.Gestion.Servicio.Interfaces
{
    public interface IClienteServicio
    {

        Task<ResponseBase> RegistrarCliente(ClienteRequest request);
        Task<ResponseBase> Actualizar(int id, ClienteRequest request);
        Task<ResponseBase<ClienteResponse>> ObtenerPorId(int id);
        Task<ResponseBase> Eliminar(int id);
        Task<PaginacionResponse<ListaClienteResponse>> Listar(BusquedaClienteRequest request);


    }
}
