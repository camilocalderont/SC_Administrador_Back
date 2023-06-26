using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Migrations
{
    public partial class addIestadoToUsuarioTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BEstado",
                table: "Usuario");

            migrationBuilder.AddColumn<int>(
                name: "IEstado",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Estado para el usuario, 0 para registrado por B2C, 1 para activo por el administrador y 2 para inactivo por el administrador");
          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IEstado",
                table: "Usuario");

            migrationBuilder.AddColumn<bool>(
                name: "BEstado",
                table: "Usuario",
                type: "bit",
                maxLength: 100,
                nullable: false,
                defaultValue: false,
                comment: "Estado para el usuario, 0 para registrado por B2C o inactivo, 1 para actualizado por el sistema");
            
        }
    }
}
