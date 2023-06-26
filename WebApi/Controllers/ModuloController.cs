using Aplicacion.ManejadorErrores;
using Aplicacion.Services;
using Dominio.Administrador;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection;
using WebApi.Responses;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuloController : ControllerBase
    {
        private readonly IGenericService<Modulo> _service;
        public ModuloController(IGenericService<Modulo> service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modulo>>> GetModulo()
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se encontró modulo", Codigo = HttpStatusCode.OK };
            IEnumerable<Modulo> ActividadesModel = null;
            if (!await _service.ExistsAsync(e => e.Id > 0))
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existe modulo", Codigo = HttpStatusCode.Accepted };
            }
            else
            {
                ActividadesModel = await _service.GetAsync();
            }
            var listModelResponse = new ListModelResponse<Modulo>(response.Codigo, response.Titulo, response.Mensaje, ActividadesModel);
            return StatusCode((int)listModelResponse.Codigo, listModelResponse);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Modulo>> GetModulo(long Id)
        {

            var response = new { Titulo = "", Mensaje = "", Codigo = HttpStatusCode.Accepted };
            Modulo ActividadModel = null;
            if (!await _service.ExistsAsync(e => e.Id > 0))
            {

                response = new { Titulo = "Algo salio mal", Mensaje = "No existen modulo", Codigo = HttpStatusCode.BadRequest };

            }

            var Actividad = await _service.GetAsync(e => e.Id == Id, e => e.OrderBy(e => e.Id), "");

            if (Actividad.Count < 1)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existe modulo con id " + Id, Codigo = HttpStatusCode.NotFound };
            }
            else
            {
                ActividadModel = Actividad.First();
                response = new { Titulo = "Bien Hecho!", Mensaje = "Se obtuvo modulo con el id solicitado", Codigo = HttpStatusCode.OK };
            }
            var modelResponse = new ModelResponse<Modulo>(response.Codigo, response.Titulo, response.Mensaje, ActividadModel);
            return StatusCode((int)modelResponse.Codigo, modelResponse);
        }

        [HttpPost]
        public async Task<ActionResult<Modulo>> PostModulo(Modulo modulo)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Modulo creado de forma correcta", Codigo = HttpStatusCode.Created };
            Modulo ActividadModel = null;

            modulo.DtFechaCreacion = DateTime.Now;
            modulo.DtFechaActualizacion = DateTime.Now;
           
            bool guardo = await _service.CreateAsync(modulo);
            if (!guardo)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No se pudo guardar modulo", Codigo = HttpStatusCode.BadRequest };
            }
            else
            {
                ActividadModel = modulo;
            }

            var modelResponse = new ModelResponse<Modulo>(response.Codigo, response.Titulo, response.Mensaje, ActividadModel);
            return StatusCode((int)modelResponse.Codigo, modelResponse);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutModulo(long Id, Modulo modulo)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se actualizó la modulo de forma correcta", Codigo = HttpStatusCode.OK };

            if (Id != modulo.Id)
            {
                response = new { Titulo = "Algo salió mal!", Mensaje = "El id de modulo no corresponde con el del modelo", Codigo = HttpStatusCode.BadRequest };
            }
            else if (modulo.Id < 1)
            {
                response = new { Titulo = "Algo salió mal!", Mensaje = "El modelo de modulo no tiene el campo Id ", Codigo = HttpStatusCode.BadRequest };
            }
            else
            {
                var Actividad = await _service.FindAsync(Id);

                if (Actividad == null)
                {
                    response = new { Titulo = "Algo salio mal", Mensaje = "No existe modulo con id " + Id, Codigo = HttpStatusCode.NotFound };
                }
                else
                {
                    modulo.DtFechaActualizacion = DateTime.Now;
                    bool updated = await _service.UpdateAsync(Id, modulo);

                    if (!updated)
                    {
                        response = new { Titulo = "Algo salió mal!", Mensaje = "No fue posible actualizar modulo", Codigo = HttpStatusCode.NoContent };
                    }
                }
            }
            var updateResponse = new GenericResponse(response.Codigo, response.Titulo, response.Mensaje);
            return StatusCode((int)updateResponse.Codigo, updateResponse);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteModulo(long Id)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se eliminó la modulo de forma correcta", Codigo = HttpStatusCode.OK };
            var Actividad = await _service.FindAsync(Id);

            if (Actividad == null)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existe modulo con id " + Id, Codigo = HttpStatusCode.NotFound };
            }
            else
            {
                bool elimino = await _service.DeleteAsync(Id);
                if (!elimino)
                {
                    response = new { Titulo = "Algo salió mal!", Mensaje = "No se pudo eliminar modulo con Id " + Id, Codigo = HttpStatusCode.NoContent };
                }
            }
            var updateResponse = new GenericResponse(response.Codigo, response.Titulo, response.Mensaje);
            return StatusCode((int)updateResponse.Codigo, updateResponse);
        }
    }
}