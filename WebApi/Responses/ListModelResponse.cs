using Dominio.Administrador;
using Dominio.Mapper;
using System.Net;

namespace WebApi.Responses
{
    public class ListModelResponse<T> : GenericResponse
    {
        private ContratoDTO atencionactorDTO;

        public IEnumerable<T> models { get; set; }

        public ListModelResponse(HttpStatusCode codigo, string titulo, string mensaje, IEnumerable<T> models) : base(codigo, titulo, mensaje)
        {
            this.models = models;
        }

        public ListModelResponse(HttpStatusCode codigo, string titulo, string mensaje, ContratoDTO atencionactorDTO) : base(codigo, titulo, mensaje)
        {
            this.atencionactorDTO = atencionactorDTO;
        }
    }

}
