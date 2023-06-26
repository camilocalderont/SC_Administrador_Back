namespace Dominio.Administrador
{
    public class UsuarioArea
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public long AreaId { get; set; }
        public DateTime DtFechaInicio  { get; set; }
        public DateTime DtFechaFin { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public DateTime DtFechaActualizacion { get; set; }
        public DateTime? DtFechaAnulacion { get; set; }


    }
}
