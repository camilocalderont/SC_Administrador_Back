using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Migrations
{
    public partial class UpdateUsuarioAzureAndUsuarioRolToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contrato_Usuario_UsuarioId",
                table: "Contrato");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioArea_Usuario_UsuarioId",
                table: "UsuarioArea");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioCargo_Usuario_UsuarioId",
                table: "UsuarioCargo");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioPuntoAtencion_Usuario_UsuarioId",
                table: "UsuarioPuntoAtencion");

            migrationBuilder.DropColumn(
                name: "TipoDocumento",
                table: "Usuario");

            migrationBuilder.AlterColumn<string>(
                name: "VcTelefono",
                table: "Usuario",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Teléfono del usuario",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VcSegundoNombre",
                table: "Usuario",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Segundo Nombre del usuario",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VcSegundoApellido",
                table: "Usuario",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Segundo Apellido del usuario",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VcPrimerNombre",
                table: "Usuario",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "Primer Nombre del usuario",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VcPrimerApellido",
                table: "Usuario",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "Primer Apellido del usuario",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VcIdAzure",
                table: "Usuario",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "Código GUID del usuario en Azure B2C",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VcDocumento",
                table: "Usuario",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                comment: "Número de documento de identidad del usuario",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VcDireccion",
                table: "Usuario",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                comment: "Dirección del usuario",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VcCorreo",
                table: "Usuario",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "Correo del usuario",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UnidadPrestacionServiciosId",
                table: "Usuario",
                type: "bigint",
                nullable: true,
                comment: "Id de tipo de la unidad de prestación de servicio del usuario, join con parametro detalle",
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "TipoEntidadId",
                table: "Usuario",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "RolId",
                table: "Usuario",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "EntidadId",
                table: "Usuario",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DtFechaCreacion",
                table: "Usuario",
                type: "datetime2",
                maxLength: 100,
                nullable: false,
                comment: "Fecha de registro del usuario",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DtFechaAnulacion",
                table: "Usuario",
                type: "datetime2",
                maxLength: 100,
                nullable: true,
                comment: "Fecha de anulación del usuario",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DtFechaActualizacion",
                table: "Usuario",
                type: "datetime2",
                maxLength: 100,
                nullable: true,
                comment: "Fecha de actualización del usuario",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "BEstado",
                table: "Usuario",
                type: "bit",
                maxLength: 100,
                nullable: false,
                comment: "Estado para el usuario, 0 para registrado por B2C o inactivo, 1 para actualizado por el sistema",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<long>(
                name: "TipoDocumentoId",
                table: "Usuario",
                type: "bigint",
                nullable: true,
                comment: "Id de tipo de documento de identidad, join con parametro detalle");

            migrationBuilder.CreateTable(
                name: "UsuarioRol",
                columns: table => new
                {
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    RolId = table.Column<long>(type: "bigint", nullable: false),
                    BEstado = table.Column<bool>(type: "bit", nullable: false),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtFechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRol", x => new { x.RolId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_UsuarioRol_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioRol_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRol_UsuarioId",
                table: "UsuarioRol",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Contrato",
                table: "Contrato",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Area",
                table: "UsuarioArea",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Cargo",
                table: "UsuarioCargo",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_PuntoAtenciones",
                table: "UsuarioPuntoAtencion",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Contrato",
                table: "Contrato");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Area",
                table: "UsuarioArea");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Cargo",
                table: "UsuarioCargo");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_PuntoAtenciones",
                table: "UsuarioPuntoAtencion");

            migrationBuilder.DropTable(
                name: "UsuarioRol");

            migrationBuilder.DropColumn(
                name: "TipoDocumentoId",
                table: "Usuario");

            migrationBuilder.AlterColumn<string>(
                name: "VcTelefono",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "Teléfono del usuario");

            migrationBuilder.AlterColumn<string>(
                name: "VcSegundoNombre",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "Segundo Nombre del usuario");

            migrationBuilder.AlterColumn<string>(
                name: "VcSegundoApellido",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "Segundo Apellido del usuario");

            migrationBuilder.AlterColumn<string>(
                name: "VcPrimerNombre",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Primer Nombre del usuario");

            migrationBuilder.AlterColumn<string>(
                name: "VcPrimerApellido",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Primer Apellido del usuario");

            migrationBuilder.AlterColumn<string>(
                name: "VcIdAzure",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Código GUID del usuario en Azure B2C");

            migrationBuilder.AlterColumn<string>(
                name: "VcDocumento",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true,
                oldComment: "Número de documento de identidad del usuario");

            migrationBuilder.AlterColumn<string>(
                name: "VcDireccion",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true,
                oldComment: "Dirección del usuario");

            migrationBuilder.AlterColumn<string>(
                name: "VcCorreo",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Correo del usuario");

            migrationBuilder.AlterColumn<long>(
                name: "UnidadPrestacionServiciosId",
                table: "Usuario",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true,
                oldComment: "Id de tipo de la unidad de prestación de servicio del usuario, join con parametro detalle");

            migrationBuilder.AlterColumn<long>(
                name: "TipoEntidadId",
                table: "Usuario",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "RolId",
                table: "Usuario",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "EntidadId",
                table: "Usuario",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DtFechaCreacion",
                table: "Usuario",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 100,
                oldComment: "Fecha de registro del usuario");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DtFechaAnulacion",
                table: "Usuario",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "Fecha de anulación del usuario");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DtFechaActualizacion",
                table: "Usuario",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "Fecha de actualización del usuario");

            migrationBuilder.AlterColumn<bool>(
                name: "BEstado",
                table: "Usuario",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldMaxLength: 100,
                oldComment: "Estado para el usuario, 0 para registrado por B2C o inactivo, 1 para actualizado por el sistema");

            migrationBuilder.AddColumn<long>(
                name: "TipoDocumento",
                table: "Usuario",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_Contrato_Usuario_UsuarioId",
                table: "Contrato",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioArea_Usuario_UsuarioId",
                table: "UsuarioArea",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioCargo_Usuario_UsuarioId",
                table: "UsuarioCargo",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioPuntoAtencion_Usuario_UsuarioId",
                table: "UsuarioPuntoAtencion",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
