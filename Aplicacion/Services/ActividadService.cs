using Dominio.Administrador;
using Dominio.Mapper;
using Persistencia.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Services
{
    public class ActividadService : GenericService<Actividad>
    {
        public ActividadRepository _actividadRepository { get; }
        public ActividadService(IGenericRepository<Actividad> genericRepository, ActividadRepository actividadRepository) : base(genericRepository)
        {
            _actividadRepository = actividadRepository;
        }

        public IEnumerable<ActividadMapper> GetActividadesPorModulo(long moduloId)
        {
            return  _actividadRepository.GetActividadesPorModulo(moduloId);
        }

        public async Task<List<ActividadHierarchyMapper>> obtenerActividadPorUsuario(long usuarioId)
        {
            var actividades = await _actividadRepository.obtenerActividadPorUsuario(usuarioId);
            var actividadesHierarchy = ConvertirActividades(actividades, 0);
            return actividadesHierarchy;
        }

        public List<ActividadHierarchyMapper> ConvertirActividades(IEnumerable<Actividad> actividades, long padreId = 0)
        {
            List<ActividadHierarchyMapper> resultado = new List<ActividadHierarchyMapper>();

            foreach (var actividad in actividades.Where(a => a.PadreId == padreId))
            {
                var actividadMapper = new ActividadHierarchyMapper()
                {
                    Id = actividad.Id,
                    ModuloId = actividad.ModuloId,
                    VcNombre = actividad.VcNombre,
                    VcDescripcion = actividad.VcDescripcion,
                    VcRedireccion = actividad.VcRedireccion,
                    IconoId = actividad.IconoId,
                    BEstado = actividad.BEstado,
                    PadreId = actividad.PadreId,
                    DtFechaCreacion = actividad.DtFechaCreacion,
                    DtFechaActualizacion = actividad.DtFechaActualizacion,
                    DtFechaAnulacion = actividad.DtFechaAnulacion,
                    BPublico = actividad.BPublico
                };

                var hijos = ConvertirActividades(actividades, actividad.Id);
                if (hijos.Any())
                {
                    actividadMapper.hijos = hijos;
                }

                resultado.Add(actividadMapper);
            }

            return resultado;
        }
    }
}
