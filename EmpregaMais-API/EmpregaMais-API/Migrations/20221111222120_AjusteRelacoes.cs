using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpregaMaisAPI.Migrations
{
    /// <inheritdoc />
    public partial class AjusteRelacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<Guid>(
                name: "IdPerfilPj",
                table: "VagasUsuarios",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdPerfilPf",
                table: "VagasUsuarios",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Logins",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeUsuario",
                table: "Logins",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdUsuario",
                table: "Logins",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdVaga",
                table: "Denuncias",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdPerfilPj",
                table: "Denuncias",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Denuncias_PerfilPj_IdPerfilPj",
                table: "Denuncias",
                column: "IdPerfilPj",
                principalTable: "PerfilPj",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Denuncias_Vagas_IdVaga",
                table: "Denuncias",
                column: "IdVaga",
                principalTable: "Vagas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Logins_Usuarios_IdUsuario",
                table: "Logins",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_PerfilPf_IdPerfil",
                table: "Usuarios",
                column: "IdPerfil",
                principalTable: "PerfilPf",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_PerfilPj_IdPerfil",
                table: "Usuarios",
                column: "IdPerfil",
                principalTable: "PerfilPj",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VagasUsuarios_PerfilPf_IdPerfilPf",
                table: "VagasUsuarios",
                column: "IdPerfilPf",
                principalTable: "PerfilPf",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VagasUsuarios_PerfilPj_IdPerfilPj",
                table: "VagasUsuarios",
                column: "IdPerfilPj",
                principalTable: "PerfilPj",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<Guid>(
                name: "IdPerfilPj",
                table: "VagasUsuarios",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdPerfilPf",
                table: "VagasUsuarios",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Logins",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "NomeUsuario",
                table: "Logins",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdUsuario",
                table: "Logins",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdVaga",
                table: "Denuncias",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdPerfilPj",
                table: "Denuncias",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Denuncias_PerfilPj_IdPerfilPj",
                table: "Denuncias",
                column: "IdPerfilPj",
                principalTable: "PerfilPj",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Denuncias_Vagas_IdVaga",
                table: "Denuncias",
                column: "IdVaga",
                principalTable: "Vagas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logins_Usuarios_IdUsuario",
                table: "Logins",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_PerfilPf_IdPerfil",
                table: "Usuarios",
                column: "IdPerfil",
                principalTable: "PerfilPf",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_PerfilPj_IdPerfil",
                table: "Usuarios",
                column: "IdPerfil",
                principalTable: "PerfilPj",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VagasUsuarios_PerfilPf_IdPerfilPf",
                table: "VagasUsuarios",
                column: "IdPerfilPf",
                principalTable: "PerfilPf",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VagasUsuarios_PerfilPj_IdPerfilPj",
                table: "VagasUsuarios",
                column: "IdPerfilPj",
                principalTable: "PerfilPj",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
