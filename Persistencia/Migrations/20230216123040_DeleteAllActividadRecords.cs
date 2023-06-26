using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Migrations
{
    public partial class DeleteAllActividadRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM ActividadRol", true);
            migrationBuilder.Sql("DELETE FROM Actividad", true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
