using Dominio.Administrador;
using Dominio.Mapper;
using Microsoft.EntityFrameworkCore;
using Persistencia.Context;

namespace Persistencia.Repository.Implementations
{
    public class UsuarioRolRepository : IUsuarioRolRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRolRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UsuarioRol> CreateUpdate(long usuarioId, long rolId)
        {
            UsuarioRol? entity = await _context.UsuarioRol.FirstOrDefaultAsync(x => x.UsuarioId == usuarioId && x.RolId == rolId);
            if(entity == null)
            {
                entity = new()
                {
                    RolId = rolId,
                    UsuarioId = usuarioId,
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                };
                var result = await _context.UsuarioRol.AddAsync(entity);
                await _context.SaveChangesAsync();
                entity = result.Entity;
            }
            else
            {
                entity.BEstado = !entity.BEstado;
                entity.DtFechaActualizacion = DateTime.Now;
                var result = _context.Update(entity);
                await _context.SaveChangesAsync();
                entity = result.Entity;
            }
            return entity;
        }

        public async Task<IEnumerable<RolPorUsuarioDTO>> GetRolesPorUsuarioId(long usuarioId)
        {
            IEnumerable<Rol> lista = await _context.Rol
                .Include(r => r.UsuarioRoles)
                .Where(r => r.BEstado)
                .ToListAsync();

            IEnumerable<RolPorUsuarioDTO> listado = lista.Select(item => new RolPorUsuarioDTO
            {
                RolId = item.Id,
                NombreRol = item.VcNombre ?? string.Empty,
                Asignado = item.UsuarioRoles?.Any(x => x.UsuarioId == usuarioId && x.BEstado) ?? false
            });
            return listado;
        }

        public async Task<IEnumerable<Rol>> GetRolesCodigoPorUsuarioId(long usuarioId)
        {
            var roles = await _context.UsuarioRol
            .Where(x => x.UsuarioId == usuarioId && x.BEstado == true) 
            .Select(x => x.Rol)
            .Distinct()
            .ToListAsync();

            return roles;
        }
    }
}
