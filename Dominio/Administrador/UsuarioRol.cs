using System.Numerics;

namespace Dominio.Administrador
{
    public class UsuarioRol
    {
        public long UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public long RolId { get; set; }
        public Rol? Rol { get; set; }
        public Boolean BEstado { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public DateTime? DtFechaActualizacion { get; set; }
        public DateTime? DtFechaAnulacion { get; set; }

    }
}
