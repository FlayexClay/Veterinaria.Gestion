using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Gestion.Dto.Request.Mascota;
using Veterinaria.Gestion.Dto.Response.Mascota;
using Veterinaria.Gestion.Dto.Response;
using Veterinaria.Gestion.Entidades;
using Veterinaria.Gestion.Repositorios.Interfaces;
using Veterinaria.Gestion.Servicio.Interfaces;
using AutoMapper;

namespace Veterinaria.Gestion.Servicio.Implementaciones
{
    public class MascotaServicio : IMascotaServicio
    {
        private readonly IMascotaRepositorio _repositorio;
        private readonly IMapper _mapper;

        public MascotaServicio(IMascotaRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }




        public async Task<ResponseBase> RegistrarMascota(MascotaRequest request)
        {
            var respuesta = new ResponseBase();

            try
            {

                var nuevo = _mapper.Map<Mascota>(request);

                await _repositorio.AddAsync(nuevo);
                respuesta.Message = "Mascota registrado correctamente";
                respuesta.Success = true;
            }
            catch (Exception ex)
            {

                respuesta.Message = ex.Message;
                respuesta.Success = false;
            }
            return respuesta;

        }


        public async Task<ResponseBase> Actualizar(int id, MascotaRequest request)
        {
            var respuesta = new ResponseBase();

            try
            {

                var existe = await _repositorio.FindAsync(id);

                if (existe == null)
                {
                    respuesta.Message = "Mascota no existe";
                    respuesta.Success = false;
                    return respuesta;
                }

                _mapper.Map(request, existe);

                await _repositorio.UpdateAsync();
                respuesta.Message = "Mascota actualizado correctamente";
                respuesta.Success = true;
            }
            catch (Exception ex)
            {

                respuesta.Message = ex.Message;
                respuesta.Success = false;
            }
            return respuesta;

        }

        public async Task<ResponseBase<MascotaResponse>> ObtenerPorId(int id)
        {
            var respuesta = new ResponseBase<MascotaResponse>();
            try
            {
                var resultado = await _repositorio.FindAsync(id);

                if (resultado == null) throw new InvalidDataException("Mascota no existe");

                respuesta.Data = _mapper.Map<MascotaResponse>(resultado);
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
                if (resultado == null) throw new InvalidDataException("Mascota no existe");
                await _repositorio.DeleteAsync(id);

                respuesta.Message = "Mascota eliminado correctamente";
                respuesta.Success = true;
            }
            catch (Exception ex)
            {
                respuesta.Message = ex.Message;
                respuesta.Success = false;
            }
            return respuesta;
        }

        public async Task<PaginacionResponse<ListaMascotaResponse>> Listar(BusquedaMascotaRequest request)
        {
            var respuesta = new PaginacionResponse<ListaMascotaResponse>();

            try
            {
                var resultado = await _repositorio.ListAsync(
                    predicado: p => p.Activo == true &&
                    (string.IsNullOrEmpty(request.Nombre) || p.Nombre.Contains(request.Nombre)),
                    selector: p => new ListaMascotaResponse
                    {
                        Id = p.Id,
                        Nombre = p.Nombre,
                        Especie = p.Especie,
                        Raza = p.Raza,
                        Dueño = p.IdClienteNavigation.Nombre,
                        FechaNacimiento = p.FechaNacimiento,
                        Peso = p.Peso

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

