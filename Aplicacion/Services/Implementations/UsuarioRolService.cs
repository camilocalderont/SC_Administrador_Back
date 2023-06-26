using Dominio.Administrador;
using Dominio.Mapper;
using Persistencia.Repository;

namespace Aplicacion.Services.Implementations
{
    public class UsuarioRolService : IUsuarioRolService
    {
        private readonly IUsuarioRolRepository _repository;

        public UsuarioRolService(IUsuarioRolRepository repository)
        {
            _repository = repository;
        }

        public async Task<UsuarioRol> CreateUpdate(long usuarioId, long rolId)
        {
            return await _repository.CreateUpdate(usuarioId, rolId);
        }

        public async Task<IEnumerable<RolPorUsuarioDTO>> GetRolesPorUsuarioId(long usuarioId)
        {
            return await _repository.GetRolesPorUsuarioId(usuarioId);
        }

        public async Task<List<string>> GetRolesCodigoPorUsuarioId(long usuarioId)
        {
            List<string> rolesArray = new List<string>{};
            IEnumerable<Rol> roles = await _repository.GetRolesCodigoPorUsuarioId(usuarioId);
            foreach(Rol rol in roles)
            {
                rolesArray.Add(rol.VcCodigoInterno);
            }
            return rolesArray;
        }
    }
}
