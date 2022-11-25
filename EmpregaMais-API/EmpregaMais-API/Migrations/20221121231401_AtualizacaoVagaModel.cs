using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpregaMaisAPI.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoVagaModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Enderecos_IdUsuario",
                table: "Enderecos");

            migrationBuilder.AddColumn<bool>(
                name: "VagaAtiva",
                table: "Vagas",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_IdUsuario",
                table: "Enderecos",
                column: "IdUsuario",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Enderecos_IdUsuario",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "VagaAtiva",
                table: "Vagas");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_IdUsuario",
                table: "Enderecos",
                column: "IdUsuario");
        }
    }
}
