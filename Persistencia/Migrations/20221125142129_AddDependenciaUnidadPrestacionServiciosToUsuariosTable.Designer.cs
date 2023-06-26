﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia.Context;

#nullable disable

namespace Persistencia.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221125142129_AddDependenciaUnidadPrestacionServiciosToUsuariosTable")]
    partial class AddDependenciaUnidadPrestacionServiciosToUsuariosTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Dominio.Administrador.Actividad", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<bool>("BEstado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DtFechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtFechaAnulacion")
                        .HasColumnType("datetime2")
                        .HasComment("Fecha anulación del registro");

                    b.Property<DateTime>("DtFechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<long?>("IconoId")
                        .HasColumnType("bigint");

                    b.Property<long>("ModuloId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PadreId")
                        .HasMaxLength(40)
                        .HasColumnType("bigint")
                        .HasComment("Id de la actividad padre de acuerdo con la jerarquia");

                    b.Property<string>("VcDescripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("VcNombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VcRedireccion")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("ModuloId");

                    b.ToTable("Actividad", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BEstado = true,
                            DtFechaActualizacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                            DtFechaCreacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                            ModuloId = 1L,
                            VcDescripcion = "Gestión de personas",
                            VcNombre = "Personas",
                            VcRedireccion = "#"
                        },
                        new
                        {
                            Id = 2L,
                            BEstado = true,
                            DtFechaActualizacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                            DtFechaCreacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                            ModuloId = 1L,
                            VcDescripcion = "Gestión de roles",
                            VcNombre = "Roles",
                            VcRedireccion = "/actividad"
                        },
                        new
                        {
                            Id = 3L,
                            BEstado = true,
                            DtFechaActualizacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                            DtFechaCreacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                            ModuloId = 1L,
                            VcDescripcion = "Configuración General",
                            VcNombre = "Configuración",
                            VcRedireccion = "#"
                        },
                        new
                        {
                            Id = 4L,
                            BEstado = true,
                            DtFechaActualizacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                            DtFechaCreacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                            ModuloId = 1L,
                            VcDescripcion = "Gestión de usuarios",
                            VcNombre = "Uusarios",
                            VcRedireccion = "/usuario"
                        },
                        new
                        {
                            Id = 5L,
                            BEstado = true,
                            DtFechaActualizacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                            DtFechaCreacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                            ModuloId = 1L,
                            VcDescripcion = "Gestión de Cargos",
                            VcNombre = "Cargos",
                            VcRedireccion = "/cargos"
                        },
                        new
                        {
                            Id = 6L,
                            BEstado = true,
                            DtFechaActualizacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                            DtFechaCreacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                            ModuloId = 1L,
                            VcDescripcion = "Gestión de Áreas",
                            VcNombre = "Áreas",
                            VcRedireccion = "#"
                        },
                        new
                        {
                            Id = 7L,
                            BEstado = true,
                            DtFechaActualizacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                            DtFechaCreacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                            IconoId = 1L,
                            ModuloId = 1L,
                            VcDescripcion = "Gestión de Puntos de Atención",
                            VcNombre = "Puntos de Atención",
                            VcRedireccion = "#"
                        });
                });

            modelBuilder.Entity("Dominio.Administrador.ActividadRol", b =>
                {
                    b.Property<long>("RolId")
                        .HasColumnType("bigint");

                    b.Property<long>("ActividadId")
                        .HasColumnType("bigint");

                    b.HasKey("RolId", "ActividadId");

                    b.HasIndex("ActividadId");

                    b.ToTable("ActividadRol");
                });

            modelBuilder.Entity("Dominio.Administrador.Configuracion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<bool>("BDomingoLaboral")
                        .HasMaxLength(50)
                        .HasColumnType("bit");

                    b.Property<bool>("BEstado")
                        .HasColumnType("bit");

                    b.Property<bool>("BSabadoLaboral")
                        .HasMaxLength(50)
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DtFechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtFechaAnulacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtFechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IDiasLimiteRespuesta")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Configuracion", (string)null);
                });

            modelBuilder.Entity("Dominio.Administrador.Contrato", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<bool>("BEstado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DtFechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtFechaAnulacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtFechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtFechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtFechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtFechaProrroga")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtFechaTerminacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IAño")
                        .HasColumnType("int");

                    b.Property<int>("INumero")
                        .HasColumnType("int");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Contrato");
                });

            modelBuilder.Entity("Dominio.Administrador.Modulo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<bool>("BEstado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DtFechaActualizacion")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtFechaAnulacion")
                        .HasColumnType("datetime2")
                        .HasComment("Fecha Eliminacion del registro");

                    b.Property<DateTime>("DtFechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<long?>("IconoId")
                        .HasColumnType("bigint");

                    b.Property<string>("VcDescripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("VcNombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VcRedireccion")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Modulo", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BEstado = true,
                            DtFechaActualizacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                            DtFechaCreacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                            VcDescripcion = "Modulo para gestionar los permisos de los usuarios dentro del aplicativo",
                            VcNombre = "Administrador"
                        },
                        new
                        {
                            Id = 2L,
                            BEstado = true,
                            DtFechaActualizacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                            DtFechaCreacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                            VcDescripcion = "Modulo para registrar la gestión de orientación e información de la Dirección de Servicio a la Ciudadanía DSC",
                            VcNombre = "Orientación e Información"
                        },
                        new
                        {
                            Id = 3L,
                            BEstado = true,
                            DtFechaActualizacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                            DtFechaCreacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                            VcDescripcion = "Modulo para realizar seguimiento a las actividades que cumple el equipo de asistencia técnica tales como planes de acción",
                            VcNombre = "Asistencia Técnica"
                        });
                });

            modelBuilder.Entity("Dominio.Administrador.Rol", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<bool>("BEstado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DtFechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtFechaAnulacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtFechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<long>("ModuloId")
                        .HasColumnType("bigint");

                    b.Property<string>("VcCodigoInterno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VcNombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ModuloId");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("Dominio.Administrador.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<bool>("BEstado")
                        .HasColumnType("bit");

                    b.Property<long>("DependenciaId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DtFechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtFechaAnulacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtFechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("TipoDocumento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UnidadPrestacionServiciosId")
                        .HasColumnType("bigint");

                    b.Property<string>("VcCorreo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VcDireccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VcDocumento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VcIdAzure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VcPrimerApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VcPrimerNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VcSegundoApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VcSegundoNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VcTelefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Dominio.Administrador.UsuarioArea", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("AreaId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DtFechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtFechaAnulacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtFechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtFechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtFechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioArea");
                });

            modelBuilder.Entity("Dominio.Administrador.UsuarioCargo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("CargoId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DtFechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtFechaAnulacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtFechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtFechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtFechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioCargo");
                });

            modelBuilder.Entity("Dominio.Administrador.UsuarioPuntoAtencion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("DtFechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtFechaAnulacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtFechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtFechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtFechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<long>("PuntoAtencionId")
                        .HasColumnType("bigint");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioPuntoAtencion");
                });

            modelBuilder.Entity("Dominio.Administrador.Actividad", b =>
                {
                    b.HasOne("Dominio.Administrador.Modulo", "Modulo")
                        .WithMany("Actividades")
                        .HasForeignKey("ModuloId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Actividad_Modulo");

                    b.Navigation("Modulo");
                });

            modelBuilder.Entity("Dominio.Administrador.ActividadRol", b =>
                {
                    b.HasOne("Dominio.Administrador.Actividad", "Actividad")
                        .WithMany("ActividadRoles")
                        .HasForeignKey("ActividadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Administrador.Rol", "Rol")
                        .WithMany("ActividadRoles")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actividad");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Dominio.Administrador.Contrato", b =>
                {
                    b.HasOne("Dominio.Administrador.Usuario", "Usuario")
                        .WithMany("Contrato")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Dominio.Administrador.Rol", b =>
                {
                    b.HasOne("Dominio.Administrador.Modulo", "Modulo")
                        .WithMany("Roles")
                        .HasForeignKey("ModuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modulo");
                });

            modelBuilder.Entity("Dominio.Administrador.UsuarioArea", b =>
                {
                    b.HasOne("Dominio.Administrador.Usuario", "Usuario")
                        .WithMany("UsuarioAreas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Dominio.Administrador.UsuarioCargo", b =>
                {
                    b.HasOne("Dominio.Administrador.Usuario", "Usuario")
                        .WithMany("UsuarioCargos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Dominio.Administrador.UsuarioPuntoAtencion", b =>
                {
                    b.HasOne("Dominio.Administrador.Usuario", "Usuario")
                        .WithMany("UsuarioPuntoAtenciones")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Dominio.Administrador.Actividad", b =>
                {
                    b.Navigation("ActividadRoles");
                });

            modelBuilder.Entity("Dominio.Administrador.Modulo", b =>
                {
                    b.Navigation("Actividades");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("Dominio.Administrador.Rol", b =>
                {
                    b.Navigation("ActividadRoles");
                });

            modelBuilder.Entity("Dominio.Administrador.Usuario", b =>
                {
                    b.Navigation("Contrato");

                    b.Navigation("UsuarioAreas");

                    b.Navigation("UsuarioCargos");

                    b.Navigation("UsuarioPuntoAtenciones");
                });
#pragma warning restore 612, 618
        }
    }
}
