using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Administrador;
using System.Numerics;

namespace Persistencia.FluentConfig.Administrador
{
    public class RolSeederConfig

    {
        public RolSeederConfig(EntityTypeBuilder<Rol> entity)
        {
            entity.HasData(
                new Rol
                {
                    Id = 1,
                    ModuloId = 1,
                    VcNombre = "ADMINISTRADOR USUARIOS",
                    VcCodigoInterno = "ADM",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now
                },
                new Rol
                {
                    Id = 2,
                    ModuloId = 1,
                    VcNombre = "PARAMETRIZADOR",
                    VcCodigoInterno = "PARAM",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now
                },
                new Rol
                {
                    Id = 3,
                    ModuloId = 1,
                    VcNombre = "GESTIÓN DE ANS",
                    VcCodigoInterno = "ANS",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now
                },
                new Rol
                {
                    Id = 4,
                    ModuloId = 2,
                    VcNombre = "REGISTRADOR WEB",
                    VcCodigoInterno = "RWEB",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now
                },
                new Rol
                {
                    Id = 5,
                    ModuloId = 2,
                    VcNombre = "REGISTRADOR GRUPAL",
                    VcCodigoInterno = "RGRUPAL",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now
                },
                new Rol
                {
                    Id = 6,
                    ModuloId = 2,
                    VcNombre = "REGISTRADOR INDIVIDUAL",
                    VcCodigoInterno = "RINDIVIDUAL",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now
                },
                new Rol
                {
                    Id = 7,
                    ModuloId = 2,
                    VcNombre = "REGISTRADOR INDIVIDUAL LSPT",
                    VcCodigoInterno = "RINDIVIDUAL_LSPT",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now
                }                                                                                                                                              
            );
        }
    }
}