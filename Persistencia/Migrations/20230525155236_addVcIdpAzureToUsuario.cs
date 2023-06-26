using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Migrations
{
    public partial class addVcIdpAzureToUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VcIdpAzure",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VcIdpAzure",
                table: "Usuario");
          
        }
    }
}
