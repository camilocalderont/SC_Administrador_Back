using Aplicacion.ManejadorErrores;
using Aplicacion.Services;
using Dominio.Administrador;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using WebApi.Responses;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioCargoController : ControllerBase
    {
        private readonly IGenericService<UsuarioCargo> _service;
        public UsuarioCargoController(IGenericService<UsuarioCargo> service)
        {
            this._service = service;
        }


        [HttpGet("porUsuarioId/{UsuarioId}")]
        public async Task<ActionResult<IEnumerable<UsuarioCargo>>> porUsuarioId(long UsuarioId)
        {
            var response = new { Titulo = "", Mensaje = "", Codigo = HttpStatusCode.Accepted };
            IEnumerable <UsuarioCargo> UsuarioCargoModel = null;
            if (!await _service.ExistsAsync(e => e.Id > 0))
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existen usuario cargo", Codigo = HttpStatusCode.BadRequest };
            }

            var usuarioacargo= await _service.GetAsync(e => e.UsuarioId == UsuarioId, e => e.OrderBy(e => e.UsuarioId), "");

            if (usuarioacargo.Count < 1)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existe usuario cargo con id ", Codigo = HttpStatusCode.NotFound };
            }
            else
            {
                UsuarioCargoModel = usuarioacargo;
                response = new { Titulo = "Bien Hecho!", Mensaje = "Se obtuvo usuario cargo con el Id solicitado", Codigo = HttpStatusCode.OK };
            }

            var modelResponse = new ListModelResponse<UsuarioCargo>(response.Codigo, response.Titulo, response.Mensaje, UsuarioCargoModel);
            return StatusCode((int)modelResponse.Codigo, modelResponse);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<UsuarioCargo>> GetUsuarioCargoId(long Id)
        {
            var response = new { Titulo = "", Mensaje = "", Codigo = HttpStatusCode.Accepted };
            UsuarioCargo UsuarioCargoModel = null;
            if (!await _service.ExistsAsync(e => e.Id > 0))
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existen usuario cargo", Codigo = HttpStatusCode.BadRequest };
            }

            var usuariocargo = await _service.GetAsync(e => e.Id == Id, e => e.OrderBy(e => e.Id), "");

            if (usuariocargo.Count < 1)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existe usuario cargo con id " + Id, Codigo = HttpStatusCode.NotFound };
            }
            else
            {
                UsuarioCargoModel = usuariocargo.First();
                response = new { Titulo = "Bien Hecho!", Mensaje = "Se obtuvo usuario cargo con el Id solicitado", Codigo = HttpStatusCode.OK };
            }

            var modelResponse = new ModelResponse<UsuarioCargo>(response.Codigo, response.Titulo, response.Mensaje, UsuarioCargoModel);
            return StatusCode((int)modelResponse.Codigo, modelResponse);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioCargo>> PostUsuarioCargo(UsuarioCargo usuariocargo)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "UsuarioCargo creado de forma correcta", Codigo = HttpStatusCode.Created };
            UsuarioCargo UsuarioCargoModel = null;

            usuariocargo.DtFechaCreacion = DateTime.Now;
            usuariocargo.DtFechaActualizacion = DateTime.Now;

            bool guardo = await _service.CreateAsync(usuariocargo);
            if (!guardo)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No se pudo guardar usuario cargo", Codigo = HttpStatusCode.BadRequest };
            }
            else
            {
                UsuarioCargoModel = usuariocargo;
            }

            var modelResponse = new ModelResponse<UsuarioCargo>(response.Codigo, response.Titulo, response.Mensaje, UsuarioCargoModel);
            return StatusCode((int)modelResponse.Codigo, modelResponse);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutUsuarioCargo(long Id, UsuarioCargo usuariocargo)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se actualizó usuario cargo de forma correcta", Codigo = HttpStatusCode.OK };

            if (Id != usuariocargo.Id)
            {
                response = new { Titulo = "Algo salió mal!", Mensaje = "El id de usuario cargo no corresponde con el del modelo", Codigo = HttpStatusCode.BadRequest };
            }
            else if (usuariocargo.Id < 1)
            {
                response = new { Titulo = "Algo salió mal!", Mensaje = "El modelo usuario cargo no tiene el campo Id ", Codigo = HttpStatusCode.BadRequest };
            }
            else
            {
                var Actividad = await _service.FindAsync(Id);

                if (Actividad == null)
                {
                    response = new { Titulo = "Algo salio mal", Mensaje = "No existe usuario cargo con id " + Id, Codigo = HttpStatusCode.NotFound };
                }
                else
                {
                    usuariocargo.DtFechaActualizacion = DateTime.Now;

                    bool updated = await _service.UpdateAsync(Id, usuariocargo);

                    if (!updated)
                    {
                        response = new { Titulo = "Algo salió mal!", Mensaje = "No fue posible actualizar usuario cargo", Codigo = HttpStatusCode.NoContent };
                    }
                }
            }
            var updateResponse = new GenericResponse(response.Codigo, response.Titulo, response.Mensaje);
            return StatusCode((int)updateResponse.Codigo, updateResponse);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteUsuarioCargo(long Id)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se eliminó usuario cargo de forma correcta", Codigo = HttpStatusCode.OK };
            var Actividad = await _service.FindAsync(Id);

            if (Actividad == null)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existe  usuario cargo con id " + Id, Codigo = HttpStatusCode.NotFound };
            }
            else
            {
                bool elimino = await _service.DeleteAsync(Id);
                if (!elimino)
                {
                    response = new { Titulo = "Algo salió mal!", Mensaje = "No se pudo eliminar  usuario cargo con Id " + Id, Codigo = HttpStatusCode.NoContent };
                }
            }
            var updateResponse = new GenericResponse(response.Codigo, response.Titulo, response.Mensaje);
            return StatusCode((int)updateResponse.Codigo, updateResponse);
        }
    }
}
