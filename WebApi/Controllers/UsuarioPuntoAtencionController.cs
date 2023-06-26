using Aplicacion.ManejadorErrores;
using Aplicacion.Services;
using Dominio.Administrador;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi.Responses;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioPuntoAtencionController : ControllerBase
    {

        private readonly IGenericService<UsuarioPuntoAtencion> _service;
        public UsuarioPuntoAtencionController(IGenericService<UsuarioPuntoAtencion> service)
        {
            this._service = service;
        }


        [HttpGet("porUsuarioId/{UsuarioId}")]
        public async Task<ActionResult<IEnumerable<UsuarioPuntoAtencion>>> porUsuarioId(long UsuarioId)
        {
            var response = new { Titulo = "", Mensaje = "", Codigo = HttpStatusCode.Accepted };
            IEnumerable<UsuarioPuntoAtencion> UsuarioPuntoAtencionModel = null;
            if (!await _service.ExistsAsync(e => e.Id > 0))
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existen usuario punto atención", Codigo = HttpStatusCode.BadRequest };
            }

            var usuariopuntoatencion = await _service.GetAsync(e => e.UsuarioId == UsuarioId, e => e.OrderBy(e => e.UsuarioId), "");

            if (usuariopuntoatencion.Count < 1)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existe usuario punto atención con id ", Codigo = HttpStatusCode.NotFound };
            }
            else
            {
                UsuarioPuntoAtencionModel = usuariopuntoatencion;
                response = new { Titulo = "Bien Hecho!", Mensaje = "Se obtuvo usuario punto atención con el Id solicitado", Codigo = HttpStatusCode.OK };
            }

            var modelResponse = new ListModelResponse<UsuarioPuntoAtencion>(response.Codigo, response.Titulo, response.Mensaje, UsuarioPuntoAtencionModel);
            return StatusCode((int)modelResponse.Codigo, modelResponse);
        }


        [HttpGet("{Id}")]
        public async Task<ActionResult<UsuarioPuntoAtencion>> GetUsuarioPuntoAtencionId(long Id)
        {
            var response = new { Titulo = "", Mensaje = "", Codigo = HttpStatusCode.Accepted };
            UsuarioPuntoAtencion UsuarioPuntoAtencionModel = null;
            if (!await _service.ExistsAsync(e => e.Id > 0))
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existen usuario punto atención", Codigo = HttpStatusCode.BadRequest };
            }

            var usuariopuntoatencion = await _service.GetAsync(e => e.Id == Id, e => e.OrderBy(e => e.Id), "");

            if (usuariopuntoatencion.Count < 1)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existe usuario punto atención con id " + Id, Codigo = HttpStatusCode.NotFound };
            }
            else
            {
                UsuarioPuntoAtencionModel = usuariopuntoatencion.First();
                response = new { Titulo = "Bien Hecho!", Mensaje = "Se obtuvo usuario punto atención con el Id solicitado", Codigo = HttpStatusCode.OK };
            }

            var modelResponse = new ModelResponse<UsuarioPuntoAtencion>(response.Codigo, response.Titulo, response.Mensaje, UsuarioPuntoAtencionModel);
            return StatusCode((int)modelResponse.Codigo, modelResponse);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioPuntoAtencion>> PostUsuarioPuntoAtencion(UsuarioPuntoAtencion usuariopuntoatencion)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "UsuarioPuntoAtencion creado de forma correcta", Codigo = HttpStatusCode.Created };
            UsuarioPuntoAtencion UsuarioPuntoAtencionModel = null;

            usuariopuntoatencion.DtFechaCreacion = DateTime.Now;
            usuariopuntoatencion.DtFechaActualizacion = DateTime.Now;

            bool guardo = await _service.CreateAsync(usuariopuntoatencion);
            if (!guardo)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No se pudo guardar usuario punto atención", Codigo = HttpStatusCode.BadRequest };
            }
            else
            {
                UsuarioPuntoAtencionModel = usuariopuntoatencion;
            }

            var modelResponse = new ModelResponse<UsuarioPuntoAtencion>(response.Codigo, response.Titulo, response.Mensaje, UsuarioPuntoAtencionModel);
            return StatusCode((int)modelResponse.Codigo, modelResponse);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutUsuarioPuntoAtencion(long Id, UsuarioPuntoAtencion usuariopuntoatencion)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se actualizó usuario punto atención de forma correcta", Codigo = HttpStatusCode.OK };

            if (Id != usuariopuntoatencion.Id)
            {
                response = new { Titulo = "Algo salió mal!", Mensaje = "El id de  usuario punto atención no corresponde con el del modelo", Codigo = HttpStatusCode.BadRequest };
            }
            else if (usuariopuntoatencion.Id < 1)
            {
                response = new { Titulo = "Algo salió mal!", Mensaje = "El modelo usuario punto atención no tiene el campo Id ", Codigo = HttpStatusCode.BadRequest };
            }
            else
            {
                var usuariopunto = await _service.FindAsync(Id);

                if (usuariopunto == null)
                {
                    response = new { Titulo = "Algo salio mal", Mensaje = "No existe  usuario punto atención con id " + Id, Codigo = HttpStatusCode.NotFound };
                }
                else
                {
                    usuariopuntoatencion.DtFechaActualizacion = DateTime.Now;
                    bool updated = await _service.UpdateAsync(Id, usuariopuntoatencion);

                    if (!updated)
                    {
                        response = new { Titulo = "Algo salió mal!", Mensaje = "No fue posible actualizar  usuario punto atención", Codigo = HttpStatusCode.NoContent };
                    }
                }
            }
            var updateResponse = new GenericResponse(response.Codigo, response.Titulo, response.Mensaje);
            return StatusCode((int)updateResponse.Codigo, updateResponse);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteUsuarioPuntoAtencion(long Id)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se eliminó usuario punto atención de forma correcta", Codigo = HttpStatusCode.OK };
            var Actividad = await _service.FindAsync(Id);

            if (Actividad == null)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existe  usuario punto atención con id " + Id, Codigo = HttpStatusCode.NotFound };
            }
            else
            {
                bool elimino = await _service.DeleteAsync(Id);
                if (!elimino)
                {
                    response = new { Titulo = "Algo salió mal!", Mensaje = "No se pudo eliminar usuario punto atención con Id " + Id, Codigo = HttpStatusCode.NoContent };
                }
            }
            var updateResponse = new GenericResponse(response.Codigo, response.Titulo, response.Mensaje);
            return StatusCode((int)updateResponse.Codigo, updateResponse);
        }
    }
}
