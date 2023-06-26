using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Administrador;
using System.Numerics;

namespace Persistencia.FluentConfig.Administrador
{
    public class ActividadSeederConfig

    {
        public ActividadSeederConfig(EntityTypeBuilder<Actividad> entity)
        {
            entity.HasData(
                new Actividad
                {
                    Id = 11,
                    ModuloId = 1,
                    VcNombre = "Administrador",
                    VcDescripcion = "Administrador",
                    VcRedireccion = "#",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    BPublico = false,
                    PadreId = 0
                },
                new Actividad
                {
                    Id = 12,
                    ModuloId = 2,
                    VcNombre = "Orientación",
                    VcDescripcion = "Orientación e Información",
                    VcRedireccion = "#",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    BPublico = false,
                    PadreId = 0
                },
                new Actividad
                {
                    Id = 13,
                    ModuloId = 3,
                    VcNombre = "Asistencia Técnica",
                    VcDescripcion = "Asistencia Técnica",
                    VcRedireccion = "#",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    BPublico = false,
                    PadreId = 0
                },                                                
                new Actividad
                {
                    Id = 14,
                    ModuloId = 1,
                    VcNombre = "Personas",
                    VcDescripcion = "Gestión de personas",
                    VcRedireccion = "#",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    BPublico = false,
                    IconoId = 1371,
                    PadreId = 11
                },
                new Actividad
                {
                    Id = 15,
                    ModuloId = 1,
                    VcNombre = "Configuración",
                    VcDescripcion = "Configuración General",
                    VcRedireccion = "#",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    BPublico = false,
                    IconoId = 1376,
                    PadreId = 11
                },
                new Actividad
                {
                    Id = 16,
                    ModuloId = 2,
                    VcNombre = "Atenciones Individuales",
                    VcDescripcion = "Atenciones Individuales",
                    VcRedireccion = "#",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    BPublico = false,
                    PadreId = 12
                },  
                new Actividad
                {
                    Id = 17,
                    ModuloId = 2,
                    VcNombre = "Orientaciones Web",
                    VcDescripcion = "Orientaciones Web",
                    VcRedireccion = "#",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    BPublico = false,
                    PadreId = 12
                },      
                new Actividad
                {
                    Id = 18,
                    ModuloId = 2,
                    VcNombre = "Grupales y Capacitaciones",
                    VcDescripcion = "Grupales y Capacitaciones",
                    VcRedireccion = "#",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    BPublico = false,
                    PadreId = 12
                }, 
                new Actividad
                {
                    Id = 19,
                    ModuloId = 1,
                    VcNombre = "Usuarios",
                    VcDescripcion = "Usuarios",
                    VcRedireccion = "/usuarios",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    BPublico = false,
                    PadreId = 14
                },
                new Actividad
                {
                    Id = 20,
                    ModuloId = 1,
                    VcNombre = "Usuarios Roles",
                    VcDescripcion = "Usuarios Roles",
                    VcRedireccion = "/usuariosPorRoles",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    BPublico = false,
                    PadreId = 14
                }, 
                new Actividad
                {
                    Id = 21,
                    ModuloId = 1,
                    VcNombre = "Módulos",
                    VcDescripcion = "Módulos",
                    VcRedireccion = "/modulos",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    BPublico = false,
                    PadreId = 15
                }, 
                new Actividad
                {
                    Id = 22,
                    ModuloId = 1,
                    VcNombre = "Roles",
                    VcDescripcion = "Roles",
                    VcRedireccion = "/roles",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    BPublico = false,
                    PadreId = 15
                }, 
                new Actividad
                {
                    Id = 23,
                    ModuloId = 1,
                    VcNombre = "Actividades",
                    VcDescripcion = "Actividades",
                    VcRedireccion = "/actividades",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    BPublico = false,
                    PadreId = 15
                }, 
                new Actividad
                {
                    Id = 24,
                    ModuloId = 1,
                    VcNombre = "Actividades Rol",
                    VcDescripcion = "Actividades Rol",
                    VcRedireccion = "/actividadesPorRoles",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    BPublico = false,
                    PadreId = 15
                }, 
                new Actividad
                {
                    Id = 25,
                    ModuloId = 1,
                    VcNombre = "Parámetros",
                    VcDescripcion = "Parámetros",
                    VcRedireccion = "/parametros",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    BPublico = false,
                    PadreId = 15
                }, 
                new Actividad
                {
                    Id = 26,
                    ModuloId = 1,
                    VcNombre = "Semaforización",
                    VcDescripcion = "Semaforización",
                    VcRedireccion = "#",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    BPublico = false,
                    PadreId = 15
                }, 
                new Actividad
                {
                    Id = 27,
                    ModuloId = 1,
                    VcNombre = "Parametrización ANS",
                    VcDescripcion = "Parametrización ANS",
                    VcRedireccion = "/semaforizacion/parametrizacionANS",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    BPublico = false,
                    PadreId = 26
                }, 
                new Actividad
                {
                    Id = 28,
                    ModuloId = 1,
                    VcNombre = "Festivos",
                    VcDescripcion = "Festivos",
                    VcRedireccion = "/semaforizacion/festivos",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    BPublico = false,
                    PadreId = 26
                }, 
                new Actividad
                {
                    Id = 29,
                    ModuloId = 1,
                    VcNombre = "Rangos de gestión",
                    VcDescripcion = "Rangos de gestión",
                    VcRedireccion = "/semaforizacion/rangos",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    BPublico = false,
                    PadreId = 26
                }, 
                new Actividad
                {
                    Id = 30,
                    ModuloId = 2,
                    VcNombre = "Registro",
                    VcDescripcion = "Registro de orientación individual",
                    VcRedireccion = "/orientacion/individuales/registro",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    BPublico = false,
                    PadreId = 16
                }, 
                new Actividad
                {
                    Id = 31,
                    ModuloId = 2,
                    VcNombre = "Bandeja de casos",
                    VcDescripcion = "Bandeja de casos de orientación individual",
                    VcRedireccion = "/orientacion/individuales/bandeja",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    BPublico = false,
                    PadreId = 16
                }, 
                new Actividad
                {
                    Id = 32,
                    ModuloId = 2,
                    VcNombre = "Seguimiento",
                    VcDescripcion = "Seguimiento de casos de orientación individual",
                    VcRedireccion = "/orientacion/individuales/seguimiento",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    BPublico = false,
                    PadreId = 16
                }, 
                new Actividad
                {
                    Id = 33,
                    ModuloId = 2,
                    VcNombre = "Registro",
                    VcDescripcion = "Registro de orientación web",
                    VcRedireccion = "/orientacion/web/registro",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    BPublico = false,
                    PadreId = 17
                }, 
                new Actividad
                {
                    Id = 34,
                    ModuloId = 2,
                    VcNombre = "Bandeja de casos",
                    VcDescripcion = "Bandeja de casos de orientación web",
                    VcRedireccion = "/orientacion/web/bandeja",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    BPublico = false,
                    PadreId = 17
                }, 
                new Actividad
                {
                    Id = 35,
                    ModuloId = 2,
                    VcNombre = "Seguimiento",
                    VcDescripcion = "Seguimiento de casos de orientación web",
                    VcRedireccion = "/orientacion/web/seguimiento",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    BPublico = false,
                    PadreId = 17
                }, 
                new Actividad
                {
                    Id = 36,
                    ModuloId = 2,
                    VcNombre = "Registro",
                    VcDescripcion = "Registro de orientación grupal",
                    VcRedireccion = "/orientacion/grupales/registro",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    BPublico = false,
                    PadreId = 18
                }, 
                new Actividad
                {
                    Id = 37,
                    ModuloId = 2,
                    VcNombre = "Bandeja de casos",
                    VcDescripcion = "Bandeja de casos de orientación grupales",
                    VcRedireccion = "/orientacion/grupales/bandeja",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    BPublico = false,
                    PadreId = 18
                }                                                                            
            );

        }
    }
}