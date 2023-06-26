namespace Dominio.Mapper
{
    public class RolPorUsuarioDTO
    {
        public long RolId { get; set; }
        public string NombreRol { get; set; } = string.Empty;
        public bool Asignado { get; set; }
    }
}
