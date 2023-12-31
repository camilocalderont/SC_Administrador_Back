﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configuracion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDiasLimiteRespuesta = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    BSabadoLaboral = table.Column<bool>(type: "bit", maxLength: 50, nullable: false),
                    BDomingoLaboral = table.Column<bool>(type: "bit", maxLength: 50, nullable: false),
                    BEstado = table.Column<bool>(type: "bit", nullable: false),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtFechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuracion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modulo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VcNombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VcDescripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VcRedireccion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    IconoId = table.Column<long>(type: "bigint", nullable: true),
                    BEstado = table.Column<bool>(type: "bit", nullable: false),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Fecha Eliminacion del registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VcDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VcPrimerNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VcPrimerApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VcSegundoNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VcSegundoApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VcCorreo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VcTelefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VcDireccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VcIdAzure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BEstado = table.Column<bool>(type: "bit", nullable: false),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtFechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Actividad",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuloId = table.Column<long>(type: "bigint", nullable: false),
                    VcNombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VcDescripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VcRedireccion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IconoId = table.Column<long>(type: "bigint", nullable: true),
                    BEstado = table.Column<bool>(type: "bit", nullable: false),
                    PadreId = table.Column<long>(type: "bigint", maxLength: 40, nullable: true, comment: "Id de la actividad padre de acuerdo con la jerarquia"),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtFechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Fecha anulación del registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actividad_Modulo",
                        column: x => x.ModuloId,
                        principalTable: "Modulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuloId = table.Column<long>(type: "bigint", nullable: false),
                    VcNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BEstado = table.Column<bool>(type: "bit", nullable: false),
                    VcCodigoInterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtFechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rol_Modulo_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "Modulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    INumero = table.Column<int>(type: "int", nullable: false),
                    IAño = table.Column<int>(type: "int", nullable: false),
                    DtFechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaProrroga = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtFechaTerminacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BEstado = table.Column<bool>(type: "bit", nullable: false),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtFechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contrato_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioArea",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    AreaId = table.Column<long>(type: "bigint", nullable: false),
                    DtFechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioArea", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioArea_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioCargo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    CargoId = table.Column<long>(type: "bigint", nullable: false),
                    DtFechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioCargo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioCargo_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioPuntoAtencion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    PuntoAtencionId = table.Column<long>(type: "bigint", nullable: false),
                    DtFechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioPuntoAtencion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioPuntoAtencion_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActividadRol",
                columns: table => new
                {
                    ActividadId = table.Column<long>(type: "bigint", nullable: false),
                    RolId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActividadRol", x => new { x.RolId, x.ActividadId });
                    table.ForeignKey(
                        name: "FK_ActividadRol_Actividad_ActividadId",
                        column: x => x.ActividadId,
                        principalTable: "Actividad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActividadRol_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Modulo",
                columns: new[] { "Id", "BEstado", "DtFechaActualizacion", "DtFechaAnulacion", "DtFechaCreacion", "IconoId", "VcDescripcion", "VcNombre", "VcRedireccion" },
                values: new object[] { 1L, true, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, "Modulo para gestionar los permisos de los usuarios dentro del aplicativo", "Administrador", null });

            migrationBuilder.InsertData(
                table: "Modulo",
                columns: new[] { "Id", "BEstado", "DtFechaActualizacion", "DtFechaAnulacion", "DtFechaCreacion", "IconoId", "VcDescripcion", "VcNombre", "VcRedireccion" },
                values: new object[] { 2L, true, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, "Modulo para registrar la gestión de orientación e información de la Dirección de Servicio a la Ciudadanía DSC", "Orientación e Información", null });

            migrationBuilder.InsertData(
                table: "Modulo",
                columns: new[] { "Id", "BEstado", "DtFechaActualizacion", "DtFechaAnulacion", "DtFechaCreacion", "IconoId", "VcDescripcion", "VcNombre", "VcRedireccion" },
                values: new object[] { 3L, true, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, "Modulo para realizar seguimiento a las actividades que cumple el equipo de asistencia técnica tales como planes de acción", "Asistencia Técnica", null });

            migrationBuilder.InsertData(
                table: "Actividad",
                columns: new[] { "Id", "BEstado", "DtFechaActualizacion", "DtFechaAnulacion", "DtFechaCreacion", "IconoId", "ModuloId", "PadreId", "VcDescripcion", "VcNombre", "VcRedireccion" },
                values: new object[,]
                {
                    { 1L, true, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, 1L, null, "Gestión de personas", "Personas", "#" },
                    { 2L, true, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, 1L, null, "Gestión de roles", "Roles", "/actividad" },
                    { 3L, true, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, 1L, null, "Configuración General", "Configuración", "#" },
                    { 4L, true, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, 1L, null, "Gestión de usuarios", "Uusarios", "/usuario" },
                    { 5L, true, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, 1L, null, "Gestión de Cargos", "Cargos", "/cargos" },
                    { 6L, true, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, 1L, null, "Gestión de Áreas", "Áreas", "#" },
                    { 7L, true, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), 1L, 1L, null, "Gestión de Puntos de Atención", "Puntos de Atención", "#" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actividad_ModuloId",
                table: "Actividad",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_ActividadRol_ActividadId",
                table: "ActividadRol",
                column: "ActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_UsuarioId",
                table: "Contrato",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_ModuloId",
                table: "Rol",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioArea_UsuarioId",
                table: "UsuarioArea",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioCargo_UsuarioId",
                table: "UsuarioCargo",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPuntoAtencion_UsuarioId",
                table: "UsuarioPuntoAtencion",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActividadRol");

            migrationBuilder.DropTable(
                name: "Configuracion");

            migrationBuilder.DropTable(
                name: "Contrato");

            migrationBuilder.DropTable(
                name: "UsuarioArea");

            migrationBuilder.DropTable(
                name: "UsuarioCargo");

            migrationBuilder.DropTable(
                name: "UsuarioPuntoAtencion");

            migrationBuilder.DropTable(
                name: "Actividad");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Modulo");
        }
    }
}
