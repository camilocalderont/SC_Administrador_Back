using Aplicacion.ManejadorErrores;
using Aplicacion.Services;
using Dominio.Administrador;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi.Responses;
using WebApi.Requests;
using AutoMapper;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IGenericService<Usuario> _service;
        private readonly IMapper _mapper;
        public UsuarioController(IGenericService<Usuario> service,IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se encontraron los usuarios", Codigo = HttpStatusCode.OK };
            IEnumerable<Usuario> ActividadesModel = null;
            if (!await _service.ExistsAsync(e => e.Id > 0))
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existen usuarios", Codigo = HttpStatusCode.Accepted };
            }
            else
            {
                ActividadesModel = await _service.GetAsync();
            }
            var listModelResponse = new ListModelResponse<Usuario>(response.Codigo, response.Titulo, response.Mensaje, ActividadesModel);
            return StatusCode((int)listModelResponse.Codigo, listModelResponse);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Usuario>> GetUsuarioId(long Id)
        {
            var response = new { Titulo = "", Mensaje = "", Codigo = HttpStatusCode.Accepted };
            Usuario ActividadModel = null;
            if (!await _service.ExistsAsync(e => e.Id > 0))
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existen usuarios", Codigo = HttpStatusCode.BadRequest };
            }

            var usuario = await _service.GetAsync(e => e.Id == Id, e => e.OrderBy(e => e.Id), "");

            if (usuario.Count < 1)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existe usuarios con id " + Id, Codigo = HttpStatusCode.NotFound };
            }
            else
            {
                ActividadModel = usuario.First();
                response = new { Titulo = "Bien Hecho!", Mensaje = "Se obtuvo usuarios con el Id solicitado", Codigo = HttpStatusCode.OK };
            }


            var modelResponse = new ModelResponse<Usuario>(response.Codigo, response.Titulo, response.Mensaje, ActividadModel);
            return StatusCode((int)modelResponse.Codigo, modelResponse);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(UsuarioCreateRequest usuarioRequest)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Usuario obtenido de forma correcta", Codigo = HttpStatusCode.Created };
            Usuario UsuarioModel = null;
            Usuario usuarioActual = null;
            Usuario usuario = _mapper.Map<Usuario>(usuarioRequest);
            Guid guidOutput;
            bool isValidGuid = Guid.TryParse(usuario.VcIdAzure, out guidOutput);
            bool registroManual = usuario.VcIdpAzure == null;
            if (!isValidGuid)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "El código GUID del usuario de Azure es no válido", Codigo = HttpStatusCode.BadRequest };
            }
            else
            {
                bool guardo = false;
                var ExisteUsuario = await _service.GetAsync(e => e.VcIdAzure == usuario.VcIdAzure, e => e.OrderBy(e => e.Id), "");
                if(ExisteUsuario.Count() > 0)
                {
                    usuario = ExisteUsuario[0];
                    guardo = true;
                }
                else
                {
                    usuario.VcCorreo = usuario.VcCorreo.ToLower();
                    List<Usuario> ExisteUsuarioPorCorreo = new();
                    if (!registroManual)
                    {
                        ExisteUsuarioPorCorreo = await _service.GetAsync(
                                e => e.VcCorreo.ToLower() == usuario.VcCorreo && e.VcIdpAzure != usuario.VcIdpAzure, 
                                e => e.OrderBy(e => e.Id), 
                                ""
                        );
                    }
                    else
                    {
                        ExisteUsuarioPorCorreo = await _service.GetAsync(
                                e => e.VcCorreo.ToLower() == usuario.VcCorreo,
                                e => e.OrderBy(e => e.Id),
                                ""
                        );
                    }

                    
                    if(ExisteUsuarioPorCorreo.Count() > 0  )
                    {
                        usuarioActual = ExisteUsuarioPorCorreo.First();
                        string nombre = $"{usuarioActual.VcPrimerNombre} {usuarioActual.VcSegundoNombre} {usuarioActual.VcPrimerApellido} {usuarioActual.VcSegundoApellido}".Replace("  ", " ").Trim();
                        string mecanismoActual = registroManual ? "Registro manual" : usuario.VcIdpAzure;
                        string mecanismoAnterior = usuarioActual.VcIdpAzure == null ? "Registro manual" : usuarioActual.VcIdpAzure;
                        string mensaje = $"Ya existe el correo {usuario.VcCorreo} a nombre de {nombre},  con otro proveedor de identidad o mecanismo de inicio, enviado: ({mecanismoActual}), encontrado: ({mecanismoAnterior})";
                        response = new { Titulo = "Algo salio mal", Mensaje = mensaje, Codigo = HttpStatusCode.BadRequest };
                    }
                    else
                    {
                        usuario.VcPrimerApellido = usuario.VcPrimerApellido.ToUpper();
                        usuario.VcSegundoApellido = usuario.VcSegundoApellido?.ToUpper();
                        usuario.VcPrimerNombre = usuario.VcPrimerNombre.ToUpper();
                        usuario.VcSegundoNombre = usuario.VcSegundoNombre?.ToUpper();
                        usuario.DtFechaCreacion = DateTime.Now;
                        usuario.DtFechaActualizacion = DateTime.Now;
                        usuario.IEstado = EstadoUsuario.Registrado;
                        //Debería obtener el modelo con el ID, en lugar de un bool
                        guardo = await _service.CreateAsync(usuario);
                    }

                }

                if (!guardo)
                {
                    if(usuarioActual == null)
                    {
                        response = new { Titulo = "Algo salio mal", Mensaje = "No se pudo guardar usuario", Codigo = HttpStatusCode.BadRequest };
                    }
                    else
                    {
                        UsuarioModel = usuarioActual;
                    }
                    
                }
                else
                {
                    UsuarioModel = usuario;
                }
            }



            var modelResponse = new ModelResponse<Usuario>(response.Codigo, response.Titulo, response.Mensaje, UsuarioModel);
            return StatusCode((int)modelResponse.Codigo, modelResponse);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutUsuario(long Id, UsuarioUpdateRequest usuarioRequest)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioRequest);

            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se actualizó usuario de forma correcta", Codigo = HttpStatusCode.OK };

            if (Id != usuario.Id)
            {
                response = new { Titulo = "Algo salió mal!", Mensaje = "El id de usuario no corresponde con el del modelo", Codigo = HttpStatusCode.BadRequest };
            }
            else if (usuario.Id < 1)
            {
                response = new { Titulo = "Algo salió mal!", Mensaje = "El modelo de usuario no tiene el campo Id ", Codigo = HttpStatusCode.BadRequest };
            }
            else
            {
                var usuarios = await _service.FindAsync(Id);

                if (usuarios == null)
                {
                    response = new { Titulo = "Algo salio mal", Mensaje = "No existe usuario con id " + Id, Codigo = HttpStatusCode.NotFound };
                }
                else
                {
                    usuario.VcPrimerApellido = usuario.VcPrimerApellido.ToUpper();
                    usuario.VcSegundoApellido = usuario.VcSegundoApellido.ToUpper();
                    usuario.VcPrimerNombre = usuario.VcPrimerNombre.ToUpper();
                    usuario.VcSegundoNombre = usuario.VcSegundoNombre.ToUpper();
                    usuario.DtFechaCreacion = usuarios.DtFechaCreacion;
                    usuario.DtFechaActualizacion = DateTime.Now;
                    bool updated = await _service.UpdateAsync(Id, usuario);

                    if (!updated)
                    {
                        response = new { Titulo = "Algo salió mal!", Mensaje = "No fue posible actualizar usuario", Codigo = HttpStatusCode.NoContent };
                    }
                }
            }
            var updateResponse = new GenericResponse(response.Codigo, response.Titulo, response.Mensaje);
            return StatusCode((int)updateResponse.Codigo, updateResponse);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteUsuario(long Id)
        {
            var response = new { Titulo = "Bien Hecho!", Mensaje = "Se eliminó usuario de forma correcta", Codigo = HttpStatusCode.OK };
            var usuario = await _service.FindAsync(Id);

            if (usuario == null)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = "No existe usuario con id " + Id, Codigo = HttpStatusCode.NotFound };
            }
            else
            {
                bool elimino = await _service.DeleteAsync(Id);
                if (!elimino)
                {
                    response = new { Titulo = "Algo salió mal!", Mensaje = "No se pudo eliminar con Id " + Id, Codigo = HttpStatusCode.NoContent };
                }
            }
            var updateResponse = new GenericResponse(response.Codigo, response.Titulo, response.Mensaje);
            return StatusCode((int)updateResponse.Codigo, updateResponse);
        }


        [HttpGet("porEstado/{estado}")]
        public async Task<ActionResult<List<Usuario>>> GetUsuariosByEstado(EstadoUsuario estado)
        {
            var response = new { Titulo = "", Mensaje = "", Codigo = HttpStatusCode.Accepted };
            List<Usuario> UsuariosModels = null;

            UsuariosModels = await _service.GetAsync(e => e.IEstado == estado, e => e.OrderBy(e => e.Id), "");

            if (UsuariosModels.Count < 1)
            {
                response = new { Titulo = "Algo salio mal", Mensaje = $"No existen usuarios con estado {estado}", Codigo = HttpStatusCode.NotFound };
            }
            else
            {
 
                response = new { Titulo = "Bien Hecho!", Mensaje = $"Se obtuvo usuarios con el estado {estado}", Codigo = HttpStatusCode.OK };
            }


            var modelResponse = new ListModelResponse<Usuario>(response.Codigo, response.Titulo, response.Mensaje, UsuariosModels);
            return StatusCode((int)HttpStatusCode.OK, modelResponse);
        }

    }







}
