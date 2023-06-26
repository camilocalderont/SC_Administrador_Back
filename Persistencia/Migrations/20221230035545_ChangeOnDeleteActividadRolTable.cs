using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Migrations
{
    public partial class ChangeOnDeleteActividadRolTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActividadRol_Actividad_ActividadId",
                table: "ActividadRol");

            migrationBuilder.DropForeignKey(
                name: "FK_ActividadRol_Rol_RolId",
                table: "ActividadRol");

            migrationBuilder.AddForeignKey(
                name: "FK_ActividadRol_Actividad_ActividadId",
                table: "ActividadRol",
                column: "ActividadId",
                principalTable: "Actividad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActividadRol_Rol_RolId",
                table: "ActividadRol",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActividadRol_Actividad_ActividadId",
                table: "ActividadRol");

            migrationBuilder.DropForeignKey(
                name: "FK_ActividadRol_Rol_RolId",
                table: "ActividadRol");

            migrationBuilder.AddForeignKey(
                name: "FK_ActividadRol_Actividad_ActividadId",
                table: "ActividadRol",
                column: "ActividadId",
                principalTable: "Actividad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActividadRol_Rol_RolId",
                table: "ActividadRol",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
