using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpregaMaisAPI.Migrations
{
    /// <inheritdoc />
    public partial class DadosPerfil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoricosAcademicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdPerfil = table.Column<Guid>(type: "uuid", nullable: false),
                    NivelEscolaridade = table.Column<int>(type: "integer", nullable: false),
                    NomeInstituicao = table.Column<string>(type: "text", nullable: false),
                    NomeCurso = table.Column<string>(type: "text", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataConclusao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Cursando = table.Column<bool>(type: "boolean", nullable: false),
                    UsuarioCriacao = table.Column<string>(type: "text", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "text", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricosAcademicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricosAcademicos_PerfilPf_IdPerfil",
                        column: x => x.IdPerfil,
                        principalTable: "PerfilPf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricosProfissionais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdPerfil = table.Column<Guid>(type: "uuid", nullable: false),
                    NomeEmpresa = table.Column<string>(type: "text", nullable: false),
                    Cargo = table.Column<string>(type: "text", nullable: false),
                    DescricaoFuncoes = table.Column<string>(type: "text", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EmpresaAtual = table.Column<bool>(type: "boolean", nullable: false),
                    UsuarioCriacao = table.Column<string>(type: "text", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "text", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricosProfissionais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricosProfissionais_PerfilPf_IdPerfil",
                        column: x => x.IdPerfil,
                        principalTable: "PerfilPf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RedesSociais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdPerfil = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Link = table.Column<string>(type: "text", nullable: false),
                    UsuarioCriacao = table.Column<string>(type: "text", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "text", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedesSociais", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricosAcademicos_IdPerfil",
                table: "HistoricosAcademicos",
                column: "IdPerfil");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricosProfissionais_IdPerfil",
                table: "HistoricosProfissionais",
                column: "IdPerfil");

            migrationBuilder.CreateIndex(
                name: "IX_RedesSociais_IdPerfil",
                table: "RedesSociais",
                column: "IdPerfil");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricosAcademicos");

            migrationBuilder.DropTable(
                name: "HistoricosProfissionais");

            migrationBuilder.DropTable(
                name: "RedesSociais");
        }
    }
}
