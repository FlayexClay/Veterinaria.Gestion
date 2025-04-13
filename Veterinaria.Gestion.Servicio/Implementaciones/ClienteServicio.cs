using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Core;
using Veterinaria.Gestion.Dto.Request.Cliente;
using Veterinaria.Gestion.Dto.Response;
using Veterinaria.Gestion.Dto.Response.Cliente;
using Veterinaria.Gestion.Entidades;
using Veterinaria.Gestion.Repositorios.Interfaces;
using Veterinaria.Gestion.Servicio.Interfaces;

namespace Veterinaria.Gestion.Servicio.Implementaciones
{
    public class ClienteServicio : IClienteServicio
    {
        private readonly IClienteRepositorio _repositorio;
        private readonly IMapper _mapper;

        public ClienteServicio(IClienteRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }


        public async Task<ResponseBase> RegistrarCliente(ClienteRequest request)
        { 
            var respuesta = new ResponseBase();

            try
            {

                var nuevo = _mapper.Map<Cliente>(request);

                await _repositorio.Registrar(nuevo, request.Usuario, request.Clave);
                respuesta.Message = "Cliente registrado correctamente";
                respuesta.Success = true;
            }
            catch (Exception ex)
            {

                respuesta.Message = ex.Message;
                respuesta.Success = false;
            }
            return respuesta;

        }


        public async Task<ResponseBase> Actualizar(int id , ClienteRequest request)
        {
            var respuesta = new ResponseBase();

            try
            {

                var existe = await _repositorio.FindAsync(id);

                if (existe == null)
                {
                    respuesta.Message = "Cliente no existe";
                    respuesta.Success = false;
                    return respuesta;
                }

                   _mapper.Map(request, existe);

                await _repositorio.UpdateAsync();
                respuesta.Message = "Cliente actualizado correctamente";
                respuesta.Success = true;
            }
            catch (Exception ex)
            {

                respuesta.Message = ex.Message;
                respuesta.Success = false;
            }
            return respuesta;

        }

        public async Task<ResponseBase<ClienteResponse>> ObtenerPorId(int id)
        {
            var respuesta = new ResponseBase<ClienteResponse>();
            try
            {
                var resultado = await _repositorio.FindAsync(id);

                if (resultado == null) throw new InvalidDataException("Cliente no existe");

                respuesta.Data = _mapper.Map<ClienteResponse>(resultado);
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
                if (resultado == null) throw new InvalidDataException("Cliente no existe"); 
                await _repositorio.DeleteAsync(id);

                respuesta.Message = "Cliente eliminado correctamente";
                respuesta.Success = true;
            }
            catch (Exception ex)
            {
                respuesta.Message = ex.Message;
                respuesta.Success = false;
            }
            return respuesta;
        }

        public async Task<PaginacionResponse<ListaClienteResponse>> Listar(BusquedaClienteRequest request)
        {
            var respuesta = new PaginacionResponse<ListaClienteResponse>();

            try
            {
                var resultado = await _repositorio.ListAsync(
                    predicado: p => p.Activo == true && 
                    (string.IsNullOrEmpty(request.Nombre) || p.Nombre.Contains(request.Nombre)) &&
                    (string.IsNullOrEmpty(request.DocumentoIdentidad) || p.DocumentoIdentidad.Contains(request.DocumentoIdentidad)),
                    selector: p => new ListaClienteResponse
                    {
                        Id = p.Id,
                        Nombre = p.Nombre,
                        Apellido = p.Apellido,
                        Telefono = p.Telefono,
                        Email = p.Email,
                        Direccion = p.Direccion,
                        DocumentoIdentidad = p.DocumentoIdentidad
                    },
                    pagina: request.Pagina,
                    filas: request.Filas
                   );

                respuesta.Data = resultado.Coleccion;
                respuesta.TotalFilas = resultado.TotalRegistros;
                respuesta.TotalPaginas =(int)Math.Ceiling((double)resultado.TotalRegistros / request.Filas);
                respuesta.Success = true;
            }
            catch (Exception ex)
            {

                respuesta.Message = ex.Message;
                respuesta.Success = false;
            }
            return respuesta;
        }


        public async Task<ResponseBase<List<ClienteResponse>>> ListarDetalleByCliente(int id)
        { 
        var respuesta = new ResponseBase<List<ClienteResponse>>();

            try
            {
                var resultado = await _repositorio.ListarDetalleByCliente(id);

                if (resultado == null || !resultado.Any())
                {
                    respuesta.Message = "No se encontraron clientes";
                    respuesta.Success = false;
                    return respuesta;
                }

                // Mapear usando AutoMapper
                respuesta.Data = _mapper.Map<List<ClienteResponse>>(resultado);
                respuesta.Success = true;
                respuesta.Message = "Clientes obtenidos correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Success = false;
                respuesta.Message = "Error al obtener los clientes: " + ex.Message;
            }

            return respuesta;
        }

    }
}
