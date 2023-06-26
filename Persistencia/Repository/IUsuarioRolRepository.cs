using Dominio.Administrador;
using Dominio.Mapper;

namespace Persistencia.Repository
{
    public interface IUsuarioRolRepository
    {
        Task<UsuarioRol> CreateUpdate(long usuarioId, long rolId);
        Task<IEnumerable<RolPorUsuarioDTO>> GetRolesPorUsuarioId(long usuarioId);
        Task<IEnumerable<Rol>> GetRolesCodigoPorUsuarioId(long usuarioId);
    }
}
