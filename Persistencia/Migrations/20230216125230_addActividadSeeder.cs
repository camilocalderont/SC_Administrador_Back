using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Migrations
{
    public partial class addActividadSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actividad",
                columns: new[] { "Id", "BEstado", "BPublico", "DtFechaActualizacion", "DtFechaAnulacion", "DtFechaCreacion", "IconoId", "ModuloId", "PadreId", "VcDescripcion", "VcNombre", "VcRedireccion" },
                values: new object[,]
                {
                    { 11L, true, false, null, null, new DateTime(2023, 2, 16, 7, 52, 30, 583, DateTimeKind.Local).AddTicks(2494), null, 1L, null, "Administrador", "Administrador", "#" },
                    { 12L, true, false, null, null, new DateTime(2023, 2, 16, 7, 52, 30, 583, DateTimeKind.Local).AddTicks(2508), null, 2L, null, "Orientación e Información", "Orientación", "#" },
                    { 13L, true, false, null, null, new DateTime(2023, 2, 16, 7, 52, 30, 583, DateTimeKind.Local).AddTicks(2509), null, 3L, null, "Asistencia Técnica", "Asistencia Técnica", "#" },
                    { 14L, true, false, null, null, new DateTime(2023, 2, 16, 7, 52, 30, 583, DateTimeKind.Local).AddTicks(2510), 1371L, 1L, 11L, "Gestión de personas", "Personas", "#" },
                    { 15L, true, false, null, null, new DateTime(2023, 2, 16, 7, 52, 30, 583, DateTimeKind.Local).AddTicks(2511), 1376L, 1L, 11L, "Configuración General", "Configuración", "#" },
                    { 16L, true, false, null, null, new DateTime(2023, 2, 16, 7, 52, 30, 583, DateTimeKind.Local).AddTicks(2513), null, 2L, 12L, "Atenciones Individuales", "Atenciones Individuales", "#" },
                    { 17L, true, false, null, null, new DateTime(2023, 2, 16, 7, 52, 30, 583, DateTimeKind.Local).AddTicks(2516), null, 2L, 12L, "Orientaciones Web", "Orientaciones Web", "#" },
                    { 18L, true, false, null, null, new DateTime(2023, 2, 16, 7, 52, 30, 583, DateTimeKind.Local).AddTicks(2517), null, 2L, 12L, "Grupales y Capacitaciones", "Grupales y Capacitaciones", "#" },
                    { 19L, true, false, null, null, new DateTime(2023, 2, 16, 7, 52, 30, 583, DateTimeKind.Local).AddTicks(2518), null, 1L, 14L, "Usuarios", "Usuarios", "/usuarios" },
                    { 20L, true, false, null, null, new DateTime(2023, 2, 16, 7, 52, 30, 583, DateTimeKind.Local).AddTicks(2519), null, 1L, 14L, "Usuarios Roles", "Usuarios Roles", "/usuariosPorRoles" },
                    { 21L, true, false, null, null, new DateTime(2023, 2, 16, 7, 52, 30, 583, DateTimeKind.Local).AddTicks(2521), null, 1L, 15L, "Módulos", "Módulos", "/modulos" },
                    { 22L, true, false, null, null, new DateTime(2023, 2, 16, 7, 52, 30, 583, DateTimeKind.Local).AddTicks(2522), null, 1L, 15L, "Roles", "Roles", "/roles" },
                    { 23L, true, false, null, null, new DateTime(2023, 2, 16, 7, 52, 30, 583, DateTimeKind.Local).AddTicks(2523), null, 1L, 15L, "Actividades", "Actividades", "/actividades" },
                    { 24L, true, false, null, null, new DateTime(2023, 2, 16, 7, 52, 30, 583, DateTimeKind.Local).AddTicks(2524), null, 1L, 15L, "Actividades Rol", "Actividades Rol", "/actividadesPorRoles" },
                    { 25L, true, false, null, null, new DateTime(2023, 2, 16, 7, 52, 30, 583, DateTimeKind.Local).AddTicks(2525), null, 1L, 15L, "Parámetros", "Parámetros", "/parametros" },
                    { 26L, true, false, null, null, new DateTime(2023, 2, 16, 7, 52, 30, 583, DateTimeKind.Local).AddTicks(2526), null, 1L, 15L, "Semaforización", "Semaforización", "#" },
                    { 27L, true, false, null, null, new DateTime(2023, 2, 16, 7, 52, 30, 583, DateTimeKind.Local).AddTicks(2527), null, 1L, 26L, "Parametrización ANS", "Parametrización ANS", "/semaforizacion/parametrizacionANS" },
                    { 28L, true, false, null, null, new DateTime(2023, 2, 16, 7, 52, 30, 583, DateTimeKind.Local).AddTicks(2528), null, 1L, 26L, "Festivos", "Festivos", "/semaforizacion/festivos" },
                    { 29L, true, false, null, null, new DateTime(2023, 2, 16, 7, 52, 30, 583, DateTimeKind.Local).AddTicks(2529), null, 1L, 26L, "Rangos de gestión", "Rangos de gestión", "/semaforizacion/rangos" },
                    { 30L, true, false, null, null, new DateTime(2023, 2, 16, 7, 52, 30, 583, DateTimeKind.Local).AddTicks(2530), null, 2L, 16L, "Registro de orientación individual", "Registro", "/orientacion/individuales/registro" },
                    { 31L, true, false, null, null, new DateTime(2023, 2, 16, 7, 52, 30, 583, DateTimeKind.Local).AddTicks(2531), null, 2L, 16L, "Bandeja de casos de orientación individual", "Bandeja de casos", "/orientacion/individuales/bandeja" },
                    { 32L, true, false, null, null, new DateTime(2023, 2, 16, 7, 52, 30, 583, DateTimeKind.Local).AddTicks(2532), null, 2L, 16L, "Seguimiento de casos de orientación individual", "Seguimiento", "/orientacion/individuales/seguimiento" },
                    { 33L, true, false, null, null, new DateTime(2023, 2, 16, 7, 52, 30, 583, DateTimeKind.Local).AddTicks(2533), null, 2L, 17L, "Registro de orientación web", "Registro", "/orientacion/web/registro" },
                    { 34L, true, false, null, null, new DateTime(2023, 2, 16, 7, 52, 30, 583, DateTimeKind.Local).AddTicks(2534), null, 2L, 17L, "Bandeja de casos de orientación web", "Bandeja de casos", "/orientacion/web/bandeja" },
                    { 35L, true, false, null, null, new DateTime(2023, 2, 16, 7, 52, 30, 583, DateTimeKind.Local).AddTicks(2535), null, 2L, 17L, "Seguimiento de casos de orientación web", "Seguimiento", "/orientacion/web/seguimiento" },
                    { 36L, true, false, null, null, new DateTime(2023, 2, 16, 7, 52, 30, 583, DateTimeKind.Local).AddTicks(2536), null, 2L, 17L, "Registro de orientación grupal", "Registro", "/orientacion/grupales/registro" },
                    { 37L, true, false, null, null, new DateTime(2023, 2, 16, 7, 52, 30, 583, DateTimeKind.Local).AddTicks(2537), null, 2L, 17L, "Bandeja de casos de orientación grupales", "Bandeja de casos", "/orientacion/grupales/bandeja" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actividad",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Actividad",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Actividad",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Actividad",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Actividad",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Actividad",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Actividad",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Actividad",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Actividad",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Actividad",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Actividad",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Actividad",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Actividad",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Actividad",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Actividad",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Actividad",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Actividad",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "Actividad",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "Actividad",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "Actividad",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "Actividad",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "Actividad",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "Actividad",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "Actividad",
                keyColumn: "Id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "Actividad",
                keyColumn: "Id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "Actividad",
                keyColumn: "Id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "Actividad",
                keyColumn: "Id",
                keyValue: 37L);
        }
    }
}
