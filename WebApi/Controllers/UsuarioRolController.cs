using Aplicacion.Services;
using Dominio.Administrador;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi.Responses;
using WebApi.Requests;
using AutoMapper;
using Dominio.Mapper;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioRolController : ControllerBase
    {
        private readonly IGenericService<UsuarioRol> _service;
        private readonly IUsuarioRolService _serviceRol;
        private readonly IMapper _mapper;

        public UsuarioRolController(IGenericService<UsuarioRol> service, IMapper mapper, IUsuarioRolService serviceRol)
        {
            this._service = service;
            this._mapper = mapper;
            this._serviceRol = serviceRol;
        }

        [HttpGet("porRolId/{rolId}")]
        public async Task<ActionResult<IEnumerable<UsuarioRol>>> GetPorRol(long rolId)
        {
            var response = new { Titulo = "", Mensaje = "", Codigo = HttpStatusCode.Accepted };
            IEnumerable<UsuarioRol> UsuariosRol = null;
            UsuariosRol = await _service.GetAsync(e => e.RolId == rolId, e => e.OrderBy(e => e.RolId), "");

            if (UsuariosRol.Count() == 0)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existe usuario rol con id de rol " + rolId, Codigo = HttpStatusCode.NotFound };
            }
            else
            {
                response = new { Titulo = "Bien Hecho!", Mensaje = "Se obtuvo los registros de  usuario rol con el Id solicitado", Codigo = HttpStatusCode.OK };
            }
            var modelResponse = new ListModelResponse<UsuarioRol>(response.Codigo, response.Titulo, response.Mensaje, UsuariosRol);
            return StatusCode((int)modelResponse.Codigo, modelResponse);
        }

        [HttpGet("porUsuarioId/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<RolPorUsuarioDTO>>> GetRolesPorUsuarioId(long usuarioId)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se encontraron registros", Codigo = HttpStatusCode.OK };

            try
            {
                IEnumerable<RolPorUsuarioDTO> listado = await _serviceRol.GetRolesPorUsuarioId(usuarioId);

                if (!listado.Any())
                    response = new { Titulo = "Sin registros!", Mensaje = "No se encontraron registros", Codigo = HttpStatusCode.OK };

                var listModelResponse = new ListModelResponse<RolPorUsuarioDTO>(response.Codigo, response.Titulo, response.Mensaje, listado);
                return StatusCode((int)listModelResponse.Codigo, listModelResponse);
            }
            catch (Exception ex)
            {
                response = new { Titulo = "Algo salió mal!", Mensaje = ex.Message, Codigo = HttpStatusCode.InternalServerError };

                var listModelResponse = new ListModelResponse<RolPorUsuarioDTO>(response.Codigo, response.Titulo, response.Mensaje, new List<RolPorUsuarioDTO>());
                return StatusCode((int)listModelResponse.Codigo, listModelResponse);
            }
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioRol>> PostGuardarUsuarioRol(UsuarioRolCreateRequest UsuarioRolRequest)
        {
            try
            {
                UsuarioRol result = await _serviceRol.CreateUpdate(UsuarioRolRequest.UsuarioId, UsuarioRolRequest.RolId);
                var response = new { Titulo = "Bien Hecho!", Mensaje = "Operación realizada correctamente.", Codigo = HttpStatusCode.OK };
                var modelResponse = new ModelResponse<UsuarioRol>(response.Codigo, response.Titulo, response.Mensaje, result);
                return StatusCode((int)modelResponse.Codigo, modelResponse);
            }
            catch(Exception ex)
            {
                var response = new { Titulo = "Bien Hecho!", Mensaje = "No se pudo guardar el usuario rol " + ex.Message, Codigo = HttpStatusCode.InternalServerError };
                var modelResponse = new ModelResponse<string>(response.Codigo, response.Titulo, response.Mensaje, "");
                return StatusCode((int)modelResponse.Codigo, modelResponse);
            }
        }

        [HttpGet("rolesCodigoporUsuarioId/{usuarioId}")]
        public async Task<ActionResult<List<string>>> GetRolesCodigoPorUsuarioId(long usuarioId)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se encontraron registros", Codigo = HttpStatusCode.OK };

            try
            {
                List<string> listado = await _serviceRol.GetRolesCodigoPorUsuarioId(usuarioId);

                if (!listado.Any())
                    response = new { Titulo = "Sin registros!", Mensaje = "No se encontraron registros", Codigo = HttpStatusCode.OK };

                var listModelResponse = new ListModelResponse<string>(response.Codigo, response.Titulo, response.Mensaje, listado);
                return StatusCode((int)listModelResponse.Codigo, listModelResponse);
            }
            catch (Exception ex)
            {
                response = new { Titulo = "Algo salió mal!", Mensaje = ex.Message, Codigo = HttpStatusCode.InternalServerError };

                var listModelResponse = new ListModelResponse<RolPorUsuarioDTO>(response.Codigo, response.Titulo, response.Mensaje, new List<RolPorUsuarioDTO>());
                return StatusCode((int)listModelResponse.Codigo, listModelResponse);
            }
        }        
        
    }
}
