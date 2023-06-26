using Dominio.Administrador;
using System.Numerics;

namespace WebApi.Requests
{
    public class UsuarioUpdateRequest
    {
        public long Id { get; set; }
        public long? RolId { get; set; }
        public long? TipoEntidadId { get; set; }
        public long? EntidadId { get; set; }
        public long? TipoDocumentoId { get; set; }
        public String? VcDocumento { get; set; }
        public String VcPrimerNombre { get; set; }
        public String VcPrimerApellido { get; set; }
        public String? VcSegundoNombre { get; set; }
        public String? VcSegundoApellido { get; set; }
        public String VcCorreo { get; set; }
        public String? VcTelefono { get; set; }
        public String? VcDireccion { get; set; }
        public String VcIdAzure { get; set; }
        public String? VcIdpAzure { get; set; }     
        public EstadoUsuario IEstado { get; set; }
        public long? UnidadPrestacionServiciosId { get; set; }

    }
}
