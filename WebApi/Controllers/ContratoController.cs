using Aplicacion.Services;
using AutoMapper;
using Dominio.Administrador;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi.Responses;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private readonly IGenericService<Contrato> _service;
        private readonly IMapper _mapper;
        public ContratoController(IGenericService<Contrato> service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;  
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contrato>>> GetContrato()
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se encontraron los contratos", Codigo = HttpStatusCode.OK };
            IEnumerable<Contrato> ActividadesModel = null;
            if (!await _service.ExistsAsync(e => e.Id > 0))
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existen contratos", Codigo = HttpStatusCode.Accepted };
            }
            else
            {
                ActividadesModel = await _service.GetAsync();
            }

            var listModelResponse = new ListModelResponse<Contrato>(response.Codigo, response.Titulo, response.Mensaje, ActividadesModel);
            return StatusCode((int)listModelResponse.Codigo, listModelResponse);
        }

        [HttpGet("GetUsuarioId/{Id}")]
        public async Task<ActionResult<Contrato>> GetUsuarioId(long Id)
        {
            var response = new { Titulo = "", Mensaje = "", Codigo = HttpStatusCode.Accepted };
            IEnumerable<Contrato> ActividadesModel = null;

            if (!await _service.ExistsAsync(e => e.UsuarioId > 0))
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existen usuarioid", Codigo = HttpStatusCode.BadRequest };
            }

            var Actividad = await _service.GetAsync(e => e.UsuarioId == Id, e => e.OrderBy(e => e.UsuarioId), "");

            if (Actividad.Count < 1)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existen contratos con usuarioid " + Id, Codigo = HttpStatusCode.NotFound };
            }
            else
            {
                ActividadesModel = Actividad.ToList();
                response = new { Titulo = "Bien Hecho!", Mensaje = "Se obtuvo usuarioid en contrato con el Id solicitado", Codigo = HttpStatusCode.OK };
            }
            var modelResponse = new ListModelResponse<Contrato>(response.Codigo, response.Titulo, response.Mensaje, ActividadesModel);
            return StatusCode((int)modelResponse.Codigo, modelResponse);
        }


        [HttpGet("{Id}")]
        public async Task<ActionResult<Contrato>> GetContrato(long Id)
        {
            var response = new { Titulo = "", Mensaje = "", Codigo = HttpStatusCode.Accepted };
            Contrato ActividadModel = null;
            if (!await _service.ExistsAsync(e => e.Id > 0))
            {

                response = new { Titulo = "Algo salio mal", Mensaje = "No existen contratos", Codigo = HttpStatusCode.BadRequest };

            }

            var Actividad = await _service.GetAsync(e => e.Id == Id, e => e.OrderBy(e => e.Id), "");

            if (Actividad.Count < 1)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existen contratos con id " + Id, Codigo = HttpStatusCode.NotFound };
            }
            else
            {
                ActividadModel = Actividad.First();
                response = new { Titulo = "Bien Hecho!", Mensaje = "Se obtuvo contratos con el Id solicitado", Codigo = HttpStatusCode.OK };
            }


            var modelResponse = new ModelResponse<Contrato>(response.Codigo, response.Titulo, response.Mensaje, ActividadModel);
            return StatusCode((int)modelResponse.Codigo, modelResponse);
        }

        [HttpPost]
        public async Task<ActionResult<Contrato>> PostContrato(Contrato contrato)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Contrato creado de forma correcta", Codigo = HttpStatusCode.Created };
            Contrato ActividadModel = null;

            contrato.DtFechaCreacion = DateTime.Now;
            contrato.DtFechaActualizacion = DateTime.Now;
           
            bool guardo = await _service.CreateAsync(contrato);
            if (!guardo)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No se pudo guardar contrato", Codigo = HttpStatusCode.BadRequest };
            }
            else
            {
                ActividadModel = contrato;
            }
            var modelResponse = new ModelResponse<Contrato>(response.Codigo, response.Titulo, response.Mensaje, ActividadModel);
            return StatusCode((int)modelResponse.Codigo, modelResponse);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutContrato(long Id, Contrato contrato)
        {

            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se actualizó comtrato de forma correcta", Codigo = HttpStatusCode.OK };

            if (Id != contrato.Id)
            {
                response = new { Titulo = "Algo salió mal!", Mensaje = "El id de contrato no corresponde con el del modelo", Codigo = HttpStatusCode.BadRequest };
            }
            else if (contrato.Id < 1)
            {
                response = new { Titulo = "Algo salió mal!", Mensaje = "El modelo de contrato no tiene el campo Id ", Codigo = HttpStatusCode.BadRequest };
            }
            else
            {
                var Actividad = await _service.FindAsync(Id);

                if (Actividad == null)
                {
                    response = new { Titulo = "Algo salio mal", Mensaje = "No existe contrato con id " + Id, Codigo = HttpStatusCode.NotFound };
                }
                else
                {
                    contrato.DtFechaActualizacion = DateTime.Now;
                    bool updated = await _service.UpdateAsync(Id, contrato);

                    if (!updated)
                    {
                        response = new { Titulo = "Algo salió mal!", Mensaje = "No fue posible actualizar contrato", Codigo = HttpStatusCode.NoContent };
                    }
                }
            }
            var updateResponse = new GenericResponse(response.Codigo, response.Titulo, response.Mensaje);
            return StatusCode((int)updateResponse.Codigo, updateResponse);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteContrato(long Id)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se eliminó contrato de forma correcta", Codigo = HttpStatusCode.OK };
            var Actividad = await _service.FindAsync(Id);

            if (Actividad == null)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existe contrato con id " + Id, Codigo = HttpStatusCode.NotFound };
            }
            else
            {
                bool elimino = await _service.DeleteAsync(Id);
                if (!elimino)
                {
                    response = new { Titulo = "Algo salió mal!", Mensaje = "No se pudo eliminar contrato con Id " + Id, Codigo = HttpStatusCode.NoContent };
                }
            }
            var updateResponse = new GenericResponse(response.Codigo, response.Titulo, response.Mensaje);
            return StatusCode((int)updateResponse.Codigo, updateResponse);
        }
    }
}
