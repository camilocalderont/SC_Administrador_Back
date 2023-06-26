using Dominio.Administrador;
using Dominio.Mapper;

namespace Aplicacion.Services
{
    public interface IUsuarioRolService
    {
        Task<UsuarioRol> CreateUpdate(long usuarioId, long rolId);
        Task<IEnumerable<RolPorUsuarioDTO>> GetRolesPorUsuarioId(long usuarioId);

        Task<List<string>> GetRolesCodigoPorUsuarioId(long usuarioId);
    }
}
