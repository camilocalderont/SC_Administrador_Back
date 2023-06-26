using System.Numerics;

namespace WebApi.Requests
{
    public class UsuarioRolCreateRequest
    {
        public long UsuarioId { get; set; }
        public long RolId { get; set; }      
    }
}
