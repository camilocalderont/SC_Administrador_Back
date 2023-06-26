using Aplicacion.ManejadorErrores;
using Aplicacion.Services;
using DocumentFormat.OpenXml.Office2010.Excel;
using Dominio.Administrador;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi.Responses;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioAreaController : ControllerBase
    {
        private readonly IGenericService<UsuarioArea> _service;
        public UsuarioAreaController(IGenericService<UsuarioArea> service)
        {
            this._service = service;
        }

        [HttpGet("porUsuarioId/{UsuarioId}")]
        public async Task<ActionResult<IEnumerable<UsuarioArea>>> porUsuarioId(long UsuarioId)
        {
            var response = new { Titulo = "", Mensaje = "", Codigo = HttpStatusCode.Accepted };
            IEnumerable<UsuarioArea> UsuarioAreasModel = null;
            if (!await _service.ExistsAsync(e => e.Id > 0))
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existen usuario area", Codigo = HttpStatusCode.BadRequest };
            }

            var usuarioarea = await _service.GetAsync(e => e.UsuarioId == UsuarioId, e => e.OrderBy(e => e.UsuarioId), "");

            if (usuarioarea.Count < 1)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existe usuario area con id ", Codigo = HttpStatusCode.NotFound };
            }
            else
            {
                UsuarioAreasModel = usuarioarea;
                response = new { Titulo = "Bien Hecho!", Mensaje = "Se obtuvo  usuario area con el Id solicitado", Codigo = HttpStatusCode.OK };
            }

            var modelResponse = new ListModelResponse<UsuarioArea>(response.Codigo, response.Titulo, response.Mensaje, UsuarioAreasModel);
            return StatusCode((int)modelResponse.Codigo, modelResponse);

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<UsuarioArea>> GetUsuarioAreaId(long Id)
        {
            var response = new { Titulo = "", Mensaje = "", Codigo = HttpStatusCode.Accepted };
            UsuarioArea UsuarioAreasModel = null;
            if (!await _service.ExistsAsync(e => e.Id > 0))
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existen usuario area", Codigo = HttpStatusCode.BadRequest };
            }

            var usuarioarea = await _service.GetAsync(e => e.Id == Id, e => e.OrderBy(e => e.Id), "");

            if (usuarioarea.Count < 1)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existe usuario area con id " + Id, Codigo = HttpStatusCode.NotFound };
            }
            else
            {
                UsuarioAreasModel = usuarioarea.First();
                response = new { Titulo = "Bien Hecho!", Mensaje = "Se obtuvo la actividad con el Id solicitado", Codigo = HttpStatusCode.OK };
            }

            var modelResponse = new ModelResponse<UsuarioArea>(response.Codigo, response.Titulo, response.Mensaje, UsuarioAreasModel);
            return StatusCode((int)modelResponse.Codigo, modelResponse);
        }

        [HttpPost]
        public async Task<IActionResult> PostUsuarioArea(UsuarioArea usuarioarea)
        {
                var response = new { Titulo = "Bien Hecho!", Mensaje = "UsuarioArea creado de forma correcta", Codigo = HttpStatusCode.Created };
                UsuarioArea ActividadModel = null;

                usuarioarea.DtFechaCreacion = DateTime.Now;
                usuarioarea.DtFechaActualizacion = DateTime.Now;

                bool guardo = await _service.CreateAsync(usuarioarea);
                if (!guardo)
                {
                    response = new { Titulo = "Algo salio mal", Mensaje = "No se pudo guardar usuario area", Codigo = HttpStatusCode.BadRequest };
                }
                else
                {
                    ActividadModel = usuarioarea;
                }

                var modelResponse = new ModelResponse<UsuarioArea>(response.Codigo, response.Titulo, response.Mensaje, ActividadModel);
                return StatusCode((int)modelResponse.Codigo, modelResponse);   
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutUsuarioArea(long Id, UsuarioArea usuarioarea)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se actualizó usuario area de forma correcta", Codigo = HttpStatusCode.OK };

            if (Id != usuarioarea.Id)
            {
                response = new { Titulo = "Algo salió mal!", Mensaje = "El id de usuario area no corresponde con el del modelo", Codigo = HttpStatusCode.BadRequest };
            }
            else if (usuarioarea.Id < 1)
            {
                response = new { Titulo = "Algo salió mal!", Mensaje = "El modelo deusuario area no tiene el campo Id ", Codigo = HttpStatusCode.BadRequest };
            }
            else
            {
                var Actividad = await _service.FindAsync(Id);

                if (Actividad == null)
                {
                    response = new { Titulo = "Algo salio mal", Mensaje = "No existe usuario area con id " + Id, Codigo = HttpStatusCode.NotFound };
                }
                else
                {
                    usuarioarea.DtFechaActualizacion = DateTime.Now;
                    bool updated = await _service.UpdateAsync(Id, usuarioarea);

                    if (!updated)
                    {
                        response = new { Titulo = "Algo salió mal!", Mensaje = "No fue posible actualizar usuario area", Codigo = HttpStatusCode.NoContent };
                    }
                }
            }
            var updateResponse = new GenericResponse(response.Codigo, response.Titulo, response.Mensaje);
            return StatusCode((int)updateResponse.Codigo, updateResponse);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteUsuarioArea(long Id)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se eliminó usuario area de forma correcta", Codigo = HttpStatusCode.OK };
            var Actividad = await _service.FindAsync(Id);

            if (Actividad == null)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existe  usuario area con id " + Id, Codigo = HttpStatusCode.NotFound };
            }
            else
            {
                bool elimino = await _service.DeleteAsync(Id);
                if (!elimino)
                {
                    response = new { Titulo = "Algo salió mal!", Mensaje = "No se pudo eliminar  usuario area con Id " + Id, Codigo = HttpStatusCode.NoContent };
                }
            }
            var updateResponse = new GenericResponse(response.Codigo, response.Titulo, response.Mensaje);
            return StatusCode((int)updateResponse.Codigo, updateResponse);
        }
    }

}

