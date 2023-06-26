using Aplicacion.ManejadorErrores;
using Aplicacion.Services;
using Dominio.Administrador;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Net;
using WebApi.Responses;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadRolController : ControllerBase
    {
        private readonly IGenericService<ActividadRol> _service;
        public ActividadRolController(IGenericService<ActividadRol> service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActividadRol>>> GetActividadRol()
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se encontró actividad rol", Codigo = HttpStatusCode.OK };
            IEnumerable<ActividadRol> ActividadesModel = null;
            if (!await _service.ExistsAsync(e => e.ActividadId > 0))
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existen actividades rol", Codigo = HttpStatusCode.Accepted };
            }
            else
            {
                ActividadesModel = await _service.GetAsync();
            }
            var listModelResponse = new ListModelResponse<ActividadRol>(response.Codigo, response.Titulo, response.Mensaje, ActividadesModel);
            return StatusCode((int)listModelResponse.Codigo, listModelResponse);
        }

        [HttpGet("{rolId}")]
        public async Task<ActionResult<IEnumerable<ActividadRol>>> GetActividadRol(long rolId)
        {
            var response = new { Titulo = "", Mensaje = "", Codigo = HttpStatusCode.Accepted };
            IEnumerable<ActividadRol> ActividadesModel = null;
            if (!await _service.ExistsAsync(e => e.ActividadId > 0))
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existe actividad rol", Codigo = HttpStatusCode.BadRequest };
            }

            ActividadesModel = await _service.GetAsync(e => e.RolId == rolId, e => e.OrderBy(e => e.RolId), "");

            if (ActividadesModel.Count() == 0)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existe actividad rol con id " + rolId, Codigo = HttpStatusCode.NotFound };
            }
            else
            {
                response = new { Titulo = "Bien Hecho!", Mensaje = "Se obtuvo las actividades con el Id solicitado", Codigo = HttpStatusCode.OK };
            }
            var modelResponse = new ListModelResponse<ActividadRol>(response.Codigo, response.Titulo, response.Mensaje, ActividadesModel);
            return StatusCode((int)modelResponse.Codigo, modelResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ActividadRol>> PostActividadRol(ActividadRol actividadrol)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "ActividadRol creada de forma correcta", Codigo = HttpStatusCode.Created };
            ActividadRol ActividadModel = null;

            bool guardo = await _service.CreateAsync(actividadrol);
            if (!guardo)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No se pudo guardar la actividad rol", Codigo = HttpStatusCode.BadRequest };
            }
            else
            {
                ActividadModel = actividadrol;
            }

            var modelResponse = new ModelResponse<ActividadRol>(response.Codigo, response.Titulo, response.Mensaje, ActividadModel);
            return StatusCode((int)modelResponse.Codigo, modelResponse);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutActividadRol(long Id, ActividadRol actividadrol)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se actualizó actividad rol de forma correcta", Codigo = HttpStatusCode.OK };

            if (Id != actividadrol.RolId)
            {
                response = new { Titulo = "Algo salió mal!", Mensaje = "El id de actividad rol no corresponde con el del modelo", Codigo = HttpStatusCode.BadRequest };
            }
            else if (actividadrol.RolId < 1)
            {
                response = new { Titulo = "Algo salió mal!", Mensaje = "El modelo de actividad rol no tiene el campo Id ", Codigo = HttpStatusCode.BadRequest };
            }
            else
            {
                var Actividad = await _service.FindAsync(Id);

                if (Actividad == null)
                {
                    response = new { Titulo = "Algo salio mal", Mensaje = "No existe actividad rol con id " + Id, Codigo = HttpStatusCode.NotFound };
                }
                else
                {
                    bool updated = await _service.UpdateAsync(Id, actividadrol);

                    if (!updated)
                    {
                        response = new { Titulo = "Algo salió mal!", Mensaje = "No fue posible actualizar actividad rol", Codigo = HttpStatusCode.NoContent };
                    }
                }
            }
            var updateResponse = new GenericResponse(response.Codigo, response.Titulo, response.Mensaje);
            return StatusCode((int)updateResponse.Codigo, updateResponse);


        }

        [HttpDelete("{rolId}/{actividadId}")]
        public async Task<IActionResult> DeleteActividadRol(long rolId, long actividadId)
        {
            try
            {
                var response = new { Titulo = "Bien Hecho!", Mensaje = "Se elimino la actividad rol de forma correcta", Codigo = HttpStatusCode.OK };
                ActividadRol ActividadModel = null;
                if (!await _service.ExistsAsync(e => e.ActividadId > 0 && e.RolId > 0))
                {
                    response = new { Titulo = "Algo salio mal", Mensaje = "No existe actividad rol", Codigo = HttpStatusCode.BadRequest };
                }
                else
                {
                    bool elimino = await _service.DeletePivotAsync(rolId, actividadId);
                    if (!elimino)
                    {
                        response = new { Titulo = "Algo salió mal!", Mensaje = "No se pudo eliminar la actividad rol con Id " + rolId + " y actividad Id "+ actividadId, Codigo = HttpStatusCode.NoContent };
                    }
                }

                var updateResponse = new GenericResponse(response.Codigo, response.Titulo, response.Mensaje);
                return StatusCode((int)updateResponse.Codigo, updateResponse);
            }
            catch (Exception e)
            {

                throw;
                //Entity type 'ActividadRol' is defined with a 2 - part composite key, but 1 values were passed to the 'Find' method.
                //El tipo de entidad 'ActividadRol' se define con una clave compuesta de 2 partes, pero se pasaron 1 valor al método 'Buscar'.
            }

           
        }

    }
}
