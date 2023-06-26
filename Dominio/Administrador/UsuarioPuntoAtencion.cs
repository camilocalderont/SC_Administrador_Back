using System.Numerics;

namespace Dominio.Administrador
{
    public class UsuarioPuntoAtencion
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public long PuntoAtencionId { get; set; }
        public DateTime DtFechaInicio { get; set; }
        public DateTime DtFechaFin { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public DateTime DtFechaActualizacion { get; set; }
        public DateTime? DtFechaAnulacion { get; set; }

    }
}
