using Aplicacion.ManejadorErrores;
using Aplicacion.Services;
using Dominio.Administrador;
using Dominio.Mapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi.Responses;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IGenericService<Rol> _service;

        public RolController(IGenericService<Rol> service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol>>> GetRol()
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se encontraron los roles", Codigo = HttpStatusCode.OK };
            IEnumerable<Rol> ActividadesModel = null;
            if (!await _service.ExistsAsync(e => e.Id > 0))
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existen roles", Codigo = HttpStatusCode.Accepted };
            }
            else
            {
                ActividadesModel = await _service.GetAsync();
            }
            var listModelResponse = new ListModelResponse<Rol>(response.Codigo, response.Titulo, response.Mensaje, ActividadesModel);
            return StatusCode((int)listModelResponse.Codigo, listModelResponse);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Rol>> GetRol(long Id)
        {
            var response = new { Titulo = "", Mensaje = "", Codigo = HttpStatusCode.Accepted };
            Rol ActividadModel = null;
            if (!await _service.ExistsAsync(e => e.Id > 0))
            { 
                response = new { Titulo = "Algo salio mal", Mensaje = "No existen roles", Codigo = HttpStatusCode.BadRequest };
            }

            var Actividad = await _service.GetAsync(e => e.Id == Id, e => e.OrderBy(e => e.Id), "");

            if (Actividad.Count < 1)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existe rol con id " + Id, Codigo = HttpStatusCode.NotFound };
            }
            else
            {
                ActividadModel = Actividad.First();
                response = new { Titulo = "Bien Hecho!", Mensaje = "Se obtuvo  rol con el Id solicitado", Codigo = HttpStatusCode.OK };
            }


            var modelResponse = new ModelResponse<Rol>(response.Codigo, response.Titulo, response.Mensaje, ActividadModel);
            return StatusCode((int)modelResponse.Codigo, modelResponse);
        }

        [HttpPost]
        public async Task<ActionResult<Rol>> PostRol(Rol rol)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Rol creado de forma correcta", Codigo = HttpStatusCode.Created };
            Rol ActividadModel = null;

            rol.DtFechaCreacion = DateTime.Now;
            rol.DtFechaActualizacion = DateTime.Now;
            
            bool guardo = await _service.CreateAsync(rol);
            if (!guardo)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No se puedo guardar rol", Codigo = HttpStatusCode.BadRequest };
            }
            else
            {
                ActividadModel = rol;
            }

            var modelResponse = new ModelResponse<Rol>(response.Codigo, response.Titulo, response.Mensaje, ActividadModel);
            return StatusCode((int)modelResponse.Codigo, modelResponse);

        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutRol(long Id, Rol rol)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se actualizó el rol de forma correcta", Codigo = HttpStatusCode.OK };

            if (Id != rol.Id)
            {
                response = new { Titulo = "Algo salió mal!", Mensaje = "El id del rol no corresponde con el del modelo", Codigo = HttpStatusCode.BadRequest };
            }
            else if (rol.Id < 1)
            {
                response = new { Titulo = "Algo salió mal!", Mensaje = "El modelo del rol no tiene el campo Id ", Codigo = HttpStatusCode.BadRequest };
            }
            else
            {
                var Actividad = await _service.FindAsync(Id);

                if (Actividad == null)
                {
                    response = new { Titulo = "Algo salio mal", Mensaje = "No existe rol con id " + Id, Codigo = HttpStatusCode.NotFound };
                }
                else
                {
                    rol.DtFechaActualizacion = DateTime.Now;
                    bool updated = await _service.UpdateAsync(Id, rol);

                    if (!updated)
                    {
                        response = new { Titulo = "Algo salió mal!", Mensaje = "No fue posible actualizar el rol", Codigo = HttpStatusCode.NoContent };
                    }
                }
            }
            var updateResponse = new GenericResponse(response.Codigo, response.Titulo, response.Mensaje);
            return StatusCode((int)updateResponse.Codigo, updateResponse);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteRol(long Id)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se eliminó el rol de forma correcta", Codigo = HttpStatusCode.OK };
            var rol = await _service.FindAsync(Id);

            if (rol == null)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existe rol con id " + Id, Codigo = HttpStatusCode.NotFound };
            }
            else
            {
                bool elimino = await _service.DeleteAsync(Id);
                if (!elimino)
                {
                    response = new { Titulo = "Algo salió mal!", Mensaje = "No se pudo eliminar rol con Id " + Id, Codigo = HttpStatusCode.NoContent };
                }
            }
            var updateResponse = new GenericResponse(response.Codigo, response.Titulo, response.Mensaje);
            return StatusCode((int)updateResponse.Codigo, updateResponse);
        }

        [HttpGet("porCodigoInterno/{VcCodigoInterno}")]
        public async Task<ActionResult<Rol>> GetRolPorCodigo(string VcCodigoInterno)
        {
            var response = new { Titulo = "", Mensaje = "", Codigo = HttpStatusCode.Accepted };
            Rol ActividadModel = null;

            var Actividad = await _service.GetAsync(e => e.VcCodigoInterno == VcCodigoInterno, e => e.OrderBy(e => e.Id), "");

            if (Actividad.Count < 1)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existe rol con Codigo: " + VcCodigoInterno, Codigo = HttpStatusCode.NotFound };
            }
            else
            {
                ActividadModel = Actividad.First();
                response = new { Titulo = "Bien Hecho!", Mensaje = "Se obtuvo  rol con el Id solicitado", Codigo = HttpStatusCode.OK };
            }

            var modelResponse = new ModelResponse<Rol>(response.Codigo, response.Titulo, response.Mensaje, ActividadModel);
            return StatusCode((int)modelResponse.Codigo, modelResponse);
        }        
    }
}
