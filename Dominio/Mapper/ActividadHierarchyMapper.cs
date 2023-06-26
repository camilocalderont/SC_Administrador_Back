using System.Numerics;

namespace Dominio.Mapper
{
    public class ActividadHierarchyMapper
    {
        public long Id { get; set; }        
        public long ModuloId { get; set; }
        public String? VcNombre { get; set; }
        public String? VcDescripcion { get; set; }
        public String? VcRedireccion { get; set; }
        public long? IconoId { get; set; }
        public Boolean BEstado { get; set; }
        public long? PadreId { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public DateTime? DtFechaActualizacion { get; set; }
        public DateTime? DtFechaAnulacion { get; set; }
        public Boolean BPublico { get; set; }
        public virtual List <ActividadHierarchyMapper>? hijos { get; set; }
    }
}
