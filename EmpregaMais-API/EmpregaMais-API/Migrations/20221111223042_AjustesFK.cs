using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpregaMaisAPI.Migrations
{
    /// <inheritdoc />
    public partial class AjustesFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "IdPerfil",
                table: "Usuarios",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.DropForeignKey(
                name: "FK_Denuncias_PerfilPj_IdPerfilPj",
                table: "Denuncias");

            migrationBuilder.DropForeignKey(
                name: "FK_Denuncias_Vagas_IdVaga",
                table: "Denuncias");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_PerfilPf_IdPerfil",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_PerfilPj_IdPerfil",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_VagasUsuarios_PerfilPf_IdPerfilPf",
                table: "VagasUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_VagasUsuarios_PerfilPj_IdPerfilPj",
                table: "VagasUsuarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "IdPerfil",
                table: "Usuarios",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.DropForeignKey(
                name: "FK_Denuncias_PerfilPj_IdPerfilPj",
                table: "Denuncias");

            migrationBuilder.DropForeignKey(
                name: "FK_Denuncias_Vagas_IdVaga",
                table: "Denuncias");

            migrationBuilder.DropForeignKey(
                name: "FK_Logins_Usuarios_IdUsuario",
                table: "Logins");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_PerfilPf_IdPerfil",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_PerfilPj_IdPerfil",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_VagasUsuarios_PerfilPf_IdPerfilPf",
                table: "VagasUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_VagasUsuarios_PerfilPj_IdPerfilPj",
                table: "VagasUsuarios");
        }
    }
}
