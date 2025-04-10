using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Gestion.Dto.Request.Mascota;
using Veterinaria.Gestion.Dto.Response.Mascota;
using Veterinaria.Gestion.Dto.Response;

namespace Veterinaria.Gestion.Servicio.Interfaces
{
    public interface IMascotaServicio
    {
        Task<ResponseBase> RegistrarMascota(MascotaRequest request);
        Task<ResponseBase> Actualizar(int id, MascotaRequest request);
        Task<ResponseBase<MascotaResponse>> ObtenerPorId(int id);
        Task<ResponseBase> Eliminar(int id);
        Task<PaginacionResponse<ListaMascotaResponse>> Listar(BusquedaMascotaRequest request);
    }
}
