using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Gestion.Dto.Request.Veterinario;
using Veterinaria.Gestion.Dto.Response;
using Veterinaria.Gestion.Dto.Response.Veterinario;

namespace Veterinaria.Gestion.Servicio.Interfaces
{
    public interface IVeterinarioServicio
    {
        Task<ResponseBase> RegistrarVeterinario(VeterinarioRequest request);

        Task<ResponseBase> Actualizar(int id, VeterinarioRequest request);

        Task<ResponseBase<VeterinarioResponse>> ObtenerPorId(int id);

        Task<ResponseBase> Eliminar(int id);

        Task<PaginacionResponse<ListaVeterinarioResponse>> Listar(BusquedaVeterinarioRequest request);

        Task<ResponseBase<List<VeterinarioResponse>>> ListarDetalleByVeterinario(int id);
    }
}
