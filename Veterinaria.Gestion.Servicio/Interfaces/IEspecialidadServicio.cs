using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Gestion.Dto.Request.Especialidad;
using Veterinaria.Gestion.Dto.Response;
using Veterinaria.Gestion.Dto.Response.Especialidad;

namespace Veterinaria.Gestion.Servicio.Interfaces
{
    public interface IEspecialidadServicio
    {
        Task<ResponseBase> RegistrarEspecialidad(EspecialidadRequest request);
        Task<ResponseBase> Actualizar(int id, EspecialidadRequest request);
        Task<ResponseBase<EspecialidadResponse>> ObtenerPorId(int id);
        Task<ResponseBase> Eliminar(int id);
        Task<PaginacionResponse<ListaEspecialidadResponse>> Listar(BusquedaEspecialidadRequest request);
        Task<ResponseBase<List<EspecialidadResponse>>> ListarDetalleByEspecialidad(int id);
    }
}
