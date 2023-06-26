﻿using Dominio.Administrador;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.FluentConfig.Administrador
{
    public class UsuarioPuntoAtencionConfig
    {
        public UsuarioPuntoAtencionConfig(EntityTypeBuilder<UsuarioPuntoAtencion> entity)
        {

            entity.ToTable("UsuarioPuntoAtencion");
            entity.HasKey(p => p.Id);

            entity.Property(p => p.UsuarioId).IsRequired();

            entity.Property(p => p.PuntoAtencionId).IsRequired();

            entity.Property(p => p.DtFechaInicio).IsRequired();

            entity.Property(p => p.DtFechaFin).IsRequired();

            entity.Property(p => p.DtFechaCreacion).IsRequired();

            entity.Property(p => p.DtFechaActualizacion).IsRequired(false);

            entity.Property(p => p.DtFechaAnulacion).IsRequired(false);

        }
    }
}
