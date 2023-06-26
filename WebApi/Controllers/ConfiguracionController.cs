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
    public class ConfiguracionController : ControllerBase
    {
        private readonly IGenericService<Configuracion> _service;
        public ConfiguracionController(IGenericService<Configuracion> service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Configuracion>>> GetConfiguracion()
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se encontró configuración", Codigo = HttpStatusCode.OK };
            IEnumerable<Configuracion> ActividadesModel = null;
            if (!await _service.ExistsAsync(e => e.Id > 0))
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existe configuración", Codigo = HttpStatusCode.Accepted };
            }
            else
            {
                ActividadesModel = await _service.GetAsync();
            }
            var listModelResponse = new ListModelResponse<Configuracion>(response.Codigo, response.Titulo, response.Mensaje, ActividadesModel);
            return StatusCode((int)listModelResponse.Codigo, listModelResponse);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Configuracion>> GetConfiguracion(long Id)
        {
            var response = new { Titulo = "", Mensaje = "", Codigo = HttpStatusCode.Accepted };
            Configuracion ActividadModel = null;
            if (!await _service.ExistsAsync(e => e.Id > 0))
            {

                response = new { Titulo = "Algo salio mal", Mensaje = "No existen configuración", Codigo = HttpStatusCode.BadRequest };

            }

            var Actividad = await _service.GetAsync(e => e.Id == Id, e => e.OrderBy(e => e.Id), "");

            if (Actividad.Count < 1)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existe configuración con id " + Id, Codigo = HttpStatusCode.NotFound };
            }
            else
            {
                ActividadModel = Actividad.First();
                response = new { Titulo = "Bien Hecho!", Mensaje = "Se obtuvo configuración con el id solicitado", Codigo = HttpStatusCode.OK };
            }
            var modelResponse = new ModelResponse<Configuracion>(response.Codigo, response.Titulo, response.Mensaje, ActividadModel);
            return StatusCode((int)modelResponse.Codigo, modelResponse);
        }

        [HttpPost]
        public async Task<ActionResult<Configuracion>> PostConfiguracion(Configuracion configuracion)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Configuración creada de forma correcta", Codigo = HttpStatusCode.Created };
            Configuracion ActividadModel = null;

            configuracion.DtFechaCreacion = DateTime.Now;
            configuracion.DtFechaActualizacion = DateTime.Now;
            bool guardo = await _service.CreateAsync(configuracion);
            if (!guardo)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No se pudo guardar la configuración", Codigo = HttpStatusCode.BadRequest };
            }
            else
            {
                ActividadModel = configuracion;
            }

            var modelResponse = new ModelResponse<Configuracion>(response.Codigo, response.Titulo, response.Mensaje, ActividadModel);
            return StatusCode((int)modelResponse.Codigo, modelResponse);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutConfiguracion(long Id, Configuracion configuracion)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se actualizó configuración de forma correcta", Codigo = HttpStatusCode.OK };

            if (Id != configuracion.Id)
            {
                response = new { Titulo = "Algo salió mal!", Mensaje = "El id de la configuración no corresponde con el del modelo", Codigo = HttpStatusCode.BadRequest };
            }
            else if (configuracion.Id < 1)
            {
                response = new { Titulo = "Algo salió mal!", Mensaje = "El modelo de configuración no tiene el campo Id ", Codigo = HttpStatusCode.BadRequest };
            }
            else
            {
                var Actividad = await _service.FindAsync(Id);

                if (Actividad == null)
                {
                    response = new { Titulo = "Algo salio mal", Mensaje = "No existe configuración con id " + Id, Codigo = HttpStatusCode.NotFound };
                }
                else
                {
                    configuracion.DtFechaActualizacion = DateTime.Now;

                    bool updated = await _service.UpdateAsync(Id, configuracion);

                    if (!updated)
                    {
                        response = new { Titulo = "Algo salió mal!", Mensaje = "No fue posible actualizar la configuración", Codigo = HttpStatusCode.NoContent };
                    }
                }
            }
            var updateResponse = new GenericResponse(response.Codigo, response.Titulo, response.Mensaje);
            return StatusCode((int)updateResponse.Codigo, updateResponse);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteConfiguracion(long Id)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se eliminó configuración de forma correcta", Codigo = HttpStatusCode.OK };
            var Actividad = await _service.FindAsync(Id);

            if (Actividad == null)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existe configuración con id " + Id, Codigo = HttpStatusCode.NotFound };
            }
            else
            {
                bool elimino = await _service.DeleteAsync(Id);
                if (!elimino)
                {
                    response = new { Titulo = "Algo salió mal!", Mensaje = "No se pudo eliminar configuración con Id " + Id, Codigo = HttpStatusCode.NoContent };
                }
            }
            var updateResponse = new GenericResponse(response.Codigo, response.Titulo, response.Mensaje);
            return StatusCode((int)updateResponse.Codigo, updateResponse);
        }
    }
}
