using System.Numerics;

namespace Dominio.Administrador
{
    public enum EstadoUsuario
    {
        Registrado = 0,
        Activo = 1,
        Inactivo = 2
    }
    public class Usuario
    {
        public long Id { get; set; }
        public long? TipoEntidadId { get; set; }
        public long? EntidadId { get; set; }
        public long? TipoDocumentoId { get; set; }
        public String? VcDocumento { get; set; }
        public String VcPrimerNombre { get; set; } = string.Empty;
        public String VcPrimerApellido { get; set; } = string.Empty;
        public String? VcSegundoNombre { get; set; }
        public String? VcSegundoApellido { get; set; }
        public String VcCorreo { get; set; } = string.Empty;
        public String? VcTelefono { get; set; }
        public String? VcDireccion { get; set; }
        public String VcIdAzure { get; set; } = string.Empty;
        public String? VcIdpAzure { get; set; } = string.Empty;
        public EstadoUsuario IEstado { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public DateTime? DtFechaActualizacion { get; set; }
        public DateTime? DtFechaAnulacion { get; set; }
        public long? UnidadPrestacionServiciosId { get; set; }

        public virtual ICollection <Contrato>? Contrato { get; set; }
        public virtual List <UsuarioCargo>? UsuarioCargos { get; set; }
        public virtual List <UsuarioArea>? UsuarioAreas { get; set; }
        public virtual List <UsuarioPuntoAtencion>? UsuarioPuntoAtenciones { get; set; }
        public virtual List <UsuarioRol>? UsuarioRoles { get; set; }
        public virtual ICollection<Rol>? Roles { get; set; }

    }
}
