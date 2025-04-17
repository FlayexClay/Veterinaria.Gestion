using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Veterinaria.Gestion.Dto.Request.Cliente;
using Veterinaria.Gestion.Dto.Request.Veterinario;
using Veterinaria.Gestion.Dto.Response;
using Veterinaria.Gestion.Dto.Response.Cliente;
using Veterinaria.Gestion.Dto.Response.Veterinario;
using Veterinaria.Gestion.Entidades;
using Veterinaria.Gestion.Repositorios.Interfaces;
using Veterinaria.Gestion.Servicio.Interfaces;

namespace Veterinaria.Gestion.Servicio.Implementaciones
{
    public  class VeterinarioServicio : IVeterinarioServicio
    {
        private readonly IVeterinarioRepositorio _repositorio;
        private readonly IMapper _mapper;


        public VeterinarioServicio(IVeterinarioRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<ResponseBase> RegistrarVeterinario(VeterinarioRequest request)
        {
            var respuesta = new ResponseBase();

            try
            {

                var nuevo = _mapper.Map<Veterinario>(request);

                await _repositorio.Registrar(nuevo, request.Usuario, request.Clave);
                respuesta.Message = "Veterinario registrado correctamente";
                respuesta.Success = true;
            }
            catch (Exception ex)
            {

                respuesta.Message = ex.Message;
                respuesta.Success = false;
            }
            return respuesta;

        }

        public async Task<ResponseBase> Actualizar(int id, VeterinarioRequest request)
        {
            var respuesta = new ResponseBase();

            try
            {

                var existe = await _repositorio.FindAsync(id);

                if (existe == null)
                {
                    respuesta.Message = "Veterinario no existe";
                    respuesta.Success = false;
                    return respuesta;
                }

                _mapper.Map(request, existe);

                await _repositorio.UpdateAsync();
                respuesta.Message = "Veterinario actualizado correctamente";
                respuesta.Success = true;
            }
            catch (Exception ex)
            {

                respuesta.Message = ex.Message;
                respuesta.Success = false;
            }
            return respuesta;

        }

        public async Task<ResponseBase<VeterinarioResponse>> ObtenerPorId(int id)
        {
            var respuesta = new ResponseBase<VeterinarioResponse>();
            try
            {
                var resultado = await _repositorio.FindAsync(id);

                if (resultado == null) throw new InvalidDataException("Veterinario no existe");

                respuesta.Data = _mapper.Map<VeterinarioResponse>(resultado);
                respuesta.Success = true;
            }
            catch (Exception ex)
            {

                respuesta.Message = ex.Message;
                respuesta.Success = false;
            }
            return respuesta;
        }

        public async Task<ResponseBase> Eliminar(int id)
        {
            var respuesta = new ResponseBase();
            try
            {
                var resultado = await _repositorio.FindAsync(id);
                if (resultado == null) throw new InvalidDataException("Veterinario no existe");
                await _repositorio.DeleteAsync(id);

                respuesta.Message = "Veterinario eliminado correctamente";
                respuesta.Success = true;
            }
            catch (Exception ex)
            {
                respuesta.Message = ex.Message;
                respuesta.Success = false;
            }
            return respuesta;
        }

        public async Task<PaginacionResponse<ListaVeterinarioResponse>> Listar(BusquedaVeterinarioRequest request)
        {
            var respuesta = new PaginacionResponse<ListaVeterinarioResponse>();

            try
            {
                var resultado = await _repositorio.ListAsync(
                    predicado: p => p.Activo == true &&
                    (string.IsNullOrEmpty(request.Nombre) || p.Nombre.Contains(request.Nombre)) &&
                    (string.IsNullOrEmpty(request.NumeroLicencia) || p.NumeroLicencia.Contains(request.NumeroLicencia)),
                    selector: p => new ListaVeterinarioResponse
                    {
                        Id = p.Id,
                        Nombre = p.Nombre,
                        Apellido = p.Apellido,
                        Telefono = p.Telefono,
                        Email = p.Email!,
                        NumeroLicencia = p.NumeroLicencia,
                        Especialidad  = p.IdEspecialidadNavigation.Nombre,
                        DocumentoIdentidad = p.DocumentoIdentidad!,

                    },
                    pagina: request.Pagina,
                    filas: request.Filas
                   );

                respuesta.Data = resultado.Coleccion;
                respuesta.TotalFilas = resultado.TotalRegistros;
                respuesta.TotalPaginas = (int)Math.Ceiling((double)resultado.TotalRegistros / request.Filas);
                respuesta.Success = true;
            }
            catch (Exception ex)
            {

                respuesta.Message = ex.Message;
                respuesta.Success = false;
            }
            return respuesta;
        }

        public async Task<ResponseBase<List<VeterinarioResponse>>> ListarDetalleByVeterinario(int id)
        {
            var respuesta = new ResponseBase<List<VeterinarioResponse>>();

            try
            {
                var resultado = await _repositorio.ListaDetalleByVeterinario(id);

                if (resultado == null || !resultado.Any())
                {
                    respuesta.Message = "No se encontraron Veterinario";
                    respuesta.Success = false;
                    return respuesta;
                }

                // Mapear usando AutoMapper
                respuesta.Data = _mapper.Map<List<VeterinarioResponse>>(resultado);
                respuesta.Success = true;
                respuesta.Message = "Veterinarios obtenidos correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Success = false;
                respuesta.Message = "Error al obtener los veterinarios: " + ex.Message;
            }

            return respuesta;
        }

    }
}
