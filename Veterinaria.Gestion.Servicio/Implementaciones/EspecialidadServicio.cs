using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Veterinaria.Gestion.Dto.Request.Especialidad;
using Veterinaria.Gestion.Dto.Response;
using Veterinaria.Gestion.Dto.Response.Especialidad;
using Veterinaria.Gestion.Entidades;
using Veterinaria.Gestion.Repositorios.Interfaces;
using Veterinaria.Gestion.Servicio.Interfaces;

namespace Veterinaria.Gestion.Servicio.Implementaciones
{
    public class EspecialidadServicio : IEspecialidadServicio
    {
        private readonly IEspecialidadRepositorio _repositorio;
        private readonly IMapper _mapper;

        public EspecialidadServicio(IEspecialidadRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<ResponseBase> RegistrarEspecialidad(EspecialidadRequest request)
        {
            var respuesta = new ResponseBase();

            try
            {
                var nuevo = _mapper.Map<Especialidad>(request);
                await _repositorio.AddAsync(nuevo);
                respuesta.Message = "Especialidad registrada correctamente";
                respuesta.Success = true;
            }
            catch (Exception ex)
            {

                respuesta.Message = ex.Message;
                respuesta.Success = false;
            }
            return respuesta;
        }

        public async Task<ResponseBase> Actualizar(int id, EspecialidadRequest request)
        {
            var respuesta = new ResponseBase();

            try
            {
                var existe = await _repositorio.FindAsync(id);

                if (existe == null)
                {
                    respuesta.Message = "No se encontró la especialidad";
                    respuesta.Success = false;
                    return respuesta;
                }

                _mapper.Map(request, existe);

                await _repositorio.UpdateAsync();
                respuesta.Message = "Especialidad actualizada correctamente";
                respuesta.Success = true;
            }
            catch (Exception ex)
            {
                respuesta.Message = ex.Message;
                respuesta.Success = false;
            }
            return respuesta;
        }

        public async Task<ResponseBase<EspecialidadResponse>> ObtenerPorId(int id)
        { 
            var respuesta = new ResponseBase<EspecialidadResponse>();

            try
            {
                var resultado = await _repositorio.FindAsync(id);

                if (resultado == null) throw new InvalidDataException("Cliente no existe");

                respuesta.Data = _mapper.Map<EspecialidadResponse>(resultado);
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

                if(resultado == null) throw new InvalidDataException("No se encontró la especialidad");

                await _repositorio.DeleteAsync(id);

                respuesta.Message = "Especialidad eliminada correctamente";
                respuesta.Success = true;
            }
            catch (Exception ex)
            {
                respuesta.Message = ex.Message;
                respuesta.Success = false;
            }
            return respuesta;
        }

        public async Task<PaginacionResponse<ListaEspecialidadResponse>> Listar(BusquedaEspecialidadRequest request)
        {
            var respuesta = new PaginacionResponse<ListaEspecialidadResponse>();
            try
            {
                var resultado = await _repositorio.ListAsync(
                predicado: p => p.Activo == true && 
                (string.IsNullOrEmpty(request.Nombre) || p.Nombre.Contains(request.Nombre)),
                selector: p => new ListaEspecialidadResponse
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion!
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

    }
}
