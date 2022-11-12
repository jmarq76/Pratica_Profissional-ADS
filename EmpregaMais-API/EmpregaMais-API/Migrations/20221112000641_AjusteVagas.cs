using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpregaMaisAPI.Migrations
{
    /// <inheritdoc />
    public partial class AjusteVagas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VagasUsuarios_IdPerfilPj",
                table: "VagasUsuarios");

            migrationBuilder.DropColumn(
                name: "IdPerfilPj",
                table: "VagasUsuarios");

            migrationBuilder.AddColumn<Guid>(
                name: "IdPerfil",
                table: "Vagas",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Vagas_IdPerfil",
                table: "Vagas",
                column: "IdPerfil");

            migrationBuilder.AddForeignKey(
                name: "FK_Vagas_PerfilPj_IdPerfil",
                table: "Vagas",
                column: "IdPerfil",
                principalTable: "PerfilPj",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vagas_PerfilPj_IdPerfil",
                table: "Vagas");

            migrationBuilder.DropIndex(
                name: "IX_Vagas_IdPerfil",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "IdPerfil",
                table: "Vagas");

            migrationBuilder.AddColumn<Guid>(
                name: "IdPerfilPj",
                table: "VagasUsuarios",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VagasUsuarios_IdPerfilPj",
                table: "VagasUsuarios",
                column: "IdPerfilPj");

            migrationBuilder.AddForeignKey(
                name: "FK_VagasUsuarios_PerfilPj_IdPerfilPj",
                table: "VagasUsuarios",
                column: "IdPerfilPj",
                principalTable: "PerfilPj",
                principalColumn: "Id");
        }
    }
}
