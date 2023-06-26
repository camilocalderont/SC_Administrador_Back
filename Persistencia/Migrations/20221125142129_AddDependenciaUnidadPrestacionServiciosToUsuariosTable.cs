using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Migrations
{
    public partial class AddDependenciaUnidadPrestacionServiciosToUsuariosTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DependenciaId",
                table: "Usuario",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UnidadPrestacionServiciosId",
                table: "Usuario",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DependenciaId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UnidadPrestacionServiciosId",
                table: "Usuario");
        }
    }
}
