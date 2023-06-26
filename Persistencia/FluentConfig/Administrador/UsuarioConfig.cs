using Dominio.Administrador;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.FluentConfig.Administrador
{
    public class UsuarioConfig
    {
        public UsuarioConfig(EntityTypeBuilder<Usuario> entity)
        {

            entity.ToTable("Usuario");
            entity.HasKey(p => p.Id);

            entity
           .HasMany(p => p.Contrato)
           .WithOne(p => p.Usuario)
           .HasForeignKey(p => p.UsuarioId)
           .HasConstraintName("FK_Usuario_Contrato")
           .OnDelete(DeleteBehavior.Restrict);


            entity
            .HasMany(p => p.UsuarioAreas)
            .WithOne(p => p.Usuario)
            .HasForeignKey(p => p.UsuarioId)
            .HasConstraintName("FK_Usuario_Area")
            .OnDelete(DeleteBehavior.Restrict);

            entity
            .HasMany(p => p.UsuarioCargos)
            .WithOne(p => p.Usuario)
            .HasForeignKey(p => p.UsuarioId)
            .HasConstraintName("FK_Usuario_Cargo")
            .OnDelete(DeleteBehavior.Restrict);

            entity
            .HasMany(p => p.UsuarioPuntoAtenciones)
            .WithOne(p => p.Usuario)
            .HasForeignKey(p => p.UsuarioId)
            .HasConstraintName("FK_Usuario_PuntoAtenciones")
            .OnDelete(DeleteBehavior.Restrict);


            /*entity
            .HasMany(p => p.UsuarioRoles)
            .WithOne(p => p.Usuario)
            .HasForeignKey(p => p.UsuarioId)
            .HasConstraintName("FK_Usuario_Roles")
            .OnDelete(DeleteBehavior.Restrict);
            */


            entity
            .HasMany(p => p.Roles)
            .WithMany(p => p.Usuarios)
            .UsingEntity<UsuarioRol>(
                j => j
                    .HasOne(pt => pt.Rol)
                    .WithMany(t => t.UsuarioRoles)
                    .HasForeignKey(f => f.RolId)
                    .OnDelete(DeleteBehavior.Restrict),
               
                j => j
                    .HasOne(pt => pt.Usuario)
                    .WithMany(t => t.UsuarioRoles)
                    .HasForeignKey(f => f.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict),
                j => j
                    .HasKey(pt => new {pt.RolId,pt.UsuarioId})
            );




            entity.Property(p => p.TipoDocumentoId)
                .IsRequired(false)
                .HasComment("Id de tipo de documento de identidad, join con parametro detalle");

            entity.Property(p => p.VcDocumento)
                .IsRequired(false)                
                .HasMaxLength(25)
                .HasComment("Número de documento de identidad del usuario");

            entity.Property(p => p.VcPrimerNombre)
                .IsRequired()                
                .HasMaxLength(100)
                .HasComment("Primer Nombre del usuario");

            entity.Property(p => p.VcPrimerApellido)
                .IsRequired()                
                .HasMaxLength(100)
                .HasComment("Primer Apellido del usuario");

            entity.Property(p => p.UnidadPrestacionServiciosId)
                .IsRequired(false)
                .HasComment("Id de tipo de la unidad de prestación de servicio del usuario, join con parametro detalle");


            entity.Property(p => p.VcSegundoNombre)
                .IsRequired(false)                
                .HasMaxLength(100)
                .HasComment("Segundo Nombre del usuario");

            entity.Property(p => p.VcSegundoApellido)
                .IsRequired(false)                
                .HasMaxLength(100)
                .HasComment("Segundo Apellido del usuario");

            entity.Property(p => p.VcCorreo)
                .IsRequired()                
                .HasMaxLength(100)
                .HasComment("Correo del usuario");

            entity.Property(p => p.VcDireccion)
                .IsRequired(false)                
                .HasMaxLength(100)
                .HasComment("Segundo Apellido del usuario");

            entity.Property(p => p.VcIdAzure)
                .IsRequired()                
                .HasMaxLength(100)
                .HasComment("Código GUID del usuario en Azure B2C");

            entity.Property(p => p.IEstado)
                .IsRequired()
                .HasComment("Estado para el usuario, 0 para registrado por B2C, 1 para activo por el administrador y 2 para inactivo por el administrador");

            entity.Property(p => p.DtFechaCreacion)
                .IsRequired()
                .HasMaxLength(100)
                .HasComment("Fecha de registro del usuario");

            entity.Property(p => p.DtFechaActualizacion)
                .IsRequired(false)
                .HasMaxLength(100)
                .HasComment("Fecha de actualización del usuario");

            entity.Property(p => p.DtFechaAnulacion)
                .IsRequired(false)
                .HasMaxLength(100)
                .HasComment("Fecha de anulación del usuario");

            entity.Property(p => p.VcTelefono)
                .IsRequired(false)                
                .HasMaxLength(100)
                .HasComment("Teléfono del usuario");

            entity.Property(p => p.VcDireccion)
                .IsRequired(false)                
                .HasMaxLength(300)
                .HasComment("Dirección del usuario");


        }
    }
}
