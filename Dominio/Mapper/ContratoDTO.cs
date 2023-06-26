namespace Dominio.Mapper
{
    public class ContratoDTO
    {
        public long Id { get; set; }

        public long UsuarioId { get; set; }

        public int INumero { get; set; }

        public int IAño { get; set; }

        public DateTime DtFechaInicio { get; set; }

        public DateTime DtFechaFin { get; set; }

        public Boolean BProrroga { get; set; }

        public DateTime? DtFechaProrroga { get; set; }

        public Boolean BTerminacion { get; set; }

        public DateTime? DtFechaTerminacion { get; set; }

        public Boolean BEstado { get; set; }

        public DateTime DtFechaCreacion { get; set; }

        public DateTime? DtFechaActualizacion { get; set; }

        public DateTime? DtFechaAnulacion { get; set; }
    }
}
