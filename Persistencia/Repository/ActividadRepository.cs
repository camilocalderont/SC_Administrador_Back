using Dominio.Administrador;
using Dominio.Mapper;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Repository
{
    public class ActividadRepository : GenericRepository<Actividad>
    {
        public ActividadRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<ActividadMapper> GetActividadesPorModulo(long moduloId)
        {
            var actividades =  _context.Actividad
                    .Where(p => p.BEstado == true && p.ModuloId == moduloId)
                    .Select(d => new ActividadMapper
                    {
                        Id = d.Id,
                        VcNombre = d.VcNombre,
                        VcDescripcion = d.VcDescripcion,
                        VcRedireccion = d.VcRedireccion,
                        IconoId = d.IconoId,
                        BEstado = d.BEstado,
                        PadreId = d.PadreId,
                        DtFechaCreacion = d.DtFechaCreacion,
                        DtFechaActualizacion = d.DtFechaActualizacion,
                        DtFechaAnulacion= d.DtFechaAnulacion,
                        ModuloId = d.ModuloId,
                        ActividadRoles = d.ActividadRoles.
                            Select(d => new ActividadRolMapper
                            {
                               ActividadId = d.ActividadId,
                                RolId = d.RolId,
                            }).ToList(),
                        Modulo = new ModuloMapper
                        {
                            Id = d.Modulo.Id,
                            VcNombre = d.Modulo.VcNombre,
                            VcDescripcion = d.Modulo.VcDescripcion,
                            VcRedireccion  = d.Modulo.VcRedireccion,
                            IconoId = d.Modulo.IconoId,
                            BEstado = d.Modulo.BEstado,
                            DtFechaCreacion = d.Modulo.DtFechaCreacion,
                            DtFechaActualizacion = d.Modulo.DtFechaActualizacion,
                            DtFechaAnulacion = d.Modulo.DtFechaAnulacion,
                        }
                    })
                    .ToList();

            return actividades;

        }

        public async Task<IEnumerable<Actividad>> obtenerActividadPorUsuario(long usuarioId)
        {
            
            var actividades = await _context.UsuarioRol
            .Join(
                _context.ActividadRol,
                usuarioRol => usuarioRol.RolId,
                actividadRol => actividadRol.RolId,
                (usuarioRol, actividadRol) => new {
                    Actividad = actividadRol.Actividad,
                    UsuarioId = usuarioRol.UsuarioId,
                    BEstadoRolId = usuarioRol.BEstado,
                    BEstadoActividadId = actividadRol.Actividad != null ? actividadRol.Actividad.BEstado : false
                }
            )
            .Where(x => x.UsuarioId == usuarioId && x.BEstadoRolId == true && x.BEstadoActividadId == true) 
            .Select(x => x.Actividad)
            .Distinct()
            .ToListAsync();
            return actividades;
        }
    }
}
