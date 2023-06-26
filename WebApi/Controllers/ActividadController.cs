using Aplicacion.ManejadorErrores;
using Aplicacion.Services;
using DocumentFormat.OpenXml.Office2010.Excel;
using Dominio.Administrador;
using Dominio.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Net;
using WebApi.Responses;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadController : ControllerBase
    {
        private readonly ActividadService _service;
        public ActividadController(ActividadService service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actividad>>> GetActividad()
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se encontraron las actividades", Codigo = HttpStatusCode.OK };
            IEnumerable<Actividad> ActividadesModel = null ;
            if (!await _service.ExistsAsync(e => e.Id > 0))
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existen actividades", Codigo = HttpStatusCode.Accepted };
            }
            else{
                ActividadesModel = await _service.GetAsync();
            }
            var listModelResponse = new ListModelResponse<Actividad>(response.Codigo, response.Titulo, response.Mensaje, ActividadesModel);
            return StatusCode((int)listModelResponse.Codigo, listModelResponse);
        }


        [HttpGet("porModuloId/{moduloId}")]
        public async Task<ActionResult<IEnumerable<ActividadMapper>>> GetActividadesPorModulo(long moduloId)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se encontraron las actividades", Codigo = HttpStatusCode.OK };
            IEnumerable<ActividadMapper> ActividadesModel = null;
            if (!await _service.ExistsAsync(e => e.Id > 0))
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existen actividades", Codigo = HttpStatusCode.Accepted };
            }

             ActividadesModel = _service.GetActividadesPorModulo(moduloId);

            if (ActividadesModel.Count() == 0)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existen actividades con id de modulo " + moduloId, Codigo = HttpStatusCode.NotFound };
            }
            else
            {
                response = new { Titulo = "Bien Hecho!", Mensaje = "Se obtuvo las actividades con el Id de modulo solicitado", Codigo = HttpStatusCode.OK };
            }
          
            var listModelResponse = new ListModelResponse<ActividadMapper>(response.Codigo, response.Titulo, response.Mensaje, ActividadesModel);
            return StatusCode((int)listModelResponse.Codigo, listModelResponse);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetActividad(long Id)
        {
            var response = new { Titulo="", Mensaje = "",Codigo = HttpStatusCode.Accepted};
            Actividad ActividadModel = null;

            if (!await _service.ExistsAsync(e => e.Id > 0))
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existen actividades", Codigo = HttpStatusCode.BadRequest };
            }

            var Actividad = await _service.GetAsync(e => e.Id == Id, e => e.OrderBy(e => e.Id), "");

            if (Actividad.Count < 1)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existe actividad con id " + Id, Codigo = HttpStatusCode.NotFound };
            }
            else
            {
                ActividadModel = Actividad.First();
                response = new { Titulo = "Bien Hecho!", Mensaje = "Se obtuvo la actividad con el Id solicitado", Codigo = HttpStatusCode.OK };
            }


            var modelResponse = new ModelResponse<Actividad>(response.Codigo, response.Titulo, response.Mensaje, ActividadModel);           
            return StatusCode((int)modelResponse.Codigo, modelResponse);
        }

        [HttpPost]
        public async Task<IActionResult> PostActividad(Actividad actividad)
        {
                var response = new { Titulo = "Bien Hecho!", Mensaje = "Actividad creada de forma correcta", Codigo = HttpStatusCode.Created };
                Actividad ActividadModel = null;
              
                actividad.DtFechaCreacion = DateTime.Now;
                actividad.DtFechaActualizacion = DateTime.Now;
                //Debería obtener el modelo con el ID, en lugar de un bool
                bool guardo = await _service.CreateAsync(actividad);
                if (!guardo)
                {
                    response = new { Titulo = "Algo salio mal", Mensaje = "No se pudo guardar la actividad", Codigo = HttpStatusCode.BadRequest };
                }
                else
                {
                    ActividadModel = actividad;
                }
               
                var modelResponse = new ModelResponse<Actividad>(response.Codigo, response.Titulo, response.Mensaje, ActividadModel);
                return StatusCode((int)modelResponse.Codigo, modelResponse);  
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutActividad(long Id, Actividad actividad)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se actualizó la actividad de forma correcta", Codigo = HttpStatusCode.OK };
            
                if (Id != actividad.Id)
                {
                    response = new { Titulo = "Algo salió mal!", Mensaje = "El id de la actividad no corresponde con el del modelo", Codigo = HttpStatusCode.BadRequest };
                }
                else if (actividad.Id < 1)
                {
                    response = new { Titulo = "Algo salió mal!", Mensaje = "El modelo de actividad no tiene el campo Id ", Codigo = HttpStatusCode.BadRequest };
                }
                else
                {
                    var Actividad = await _service.FindAsync(Id);

                    if (Actividad == null)
                    {
                        response = new { Titulo = "Algo salio mal", Mensaje = "No existe actividad con id " + Id, Codigo = HttpStatusCode.NotFound };
                    }
                    else
                    {
                        actividad.DtFechaActualizacion = DateTime.Now;
                        bool updated = await _service.UpdateAsync(Id, actividad);

                        if (!updated)
                        {
                            response = new { Titulo = "Algo salió mal!", Mensaje = "No fue posible actualizar la actividad", Codigo = HttpStatusCode.NoContent };
                        }
                    }
                }
            var updateResponse = new GenericResponse(response.Codigo, response.Titulo, response.Mensaje);
            return StatusCode((int)updateResponse.Codigo, updateResponse);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteActividad(long Id)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se eliminó la actividad de forma correcta", Codigo = HttpStatusCode.OK };
            var Actividad = await _service.FindAsync(Id);

            if (Actividad == null)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existe actividad con id " + Id, Codigo = HttpStatusCode.NotFound };
            }
            else
            {
                bool elimino = await _service.DeleteAsync(Id);
                if (!elimino)
                {
                    response = new { Titulo = "Algo salió mal!", Mensaje = "No se pudo eliminar la actividad rol con Id " + Id, Codigo = HttpStatusCode.NoContent };
                }
            }
            var updateResponse = new GenericResponse(response.Codigo, response.Titulo, response.Mensaje);
            return StatusCode((int)updateResponse.Codigo, updateResponse);
        }

        [HttpGet("porUsuarioId/{UsuarioId}")]
        public async Task<ActionResult<List<ActividadHierarchyMapper>>> GetActividadesPorUsuario(long UsuarioId)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se encontraron las actividades", Codigo = HttpStatusCode.OK };
            List<ActividadHierarchyMapper> Actividades = new List<ActividadHierarchyMapper>();
             Actividades = await _service.obtenerActividadPorUsuario(UsuarioId);

            if (Actividades.Count() == 0)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existen actividades con id de Usuario " + UsuarioId, Codigo = HttpStatusCode.NotFound };
            }
            else
            {
                response = new { Titulo = "Bien Hecho!", Mensaje = "Se obtuvo las actividades con el Id de Usuario solicitado", Codigo = HttpStatusCode.OK };
            }
          
            var listModelResponse = new ListModelResponse<ActividadHierarchyMapper>(response.Codigo, response.Titulo, response.Mensaje, Actividades);
            return StatusCode((int)listModelResponse.Codigo, listModelResponse);
        }
    }

}
