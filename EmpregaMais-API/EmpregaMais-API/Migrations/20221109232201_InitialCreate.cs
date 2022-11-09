using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpregaMaisAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vagas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "text", nullable: true),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    DataExpiracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NivelSenioridade = table.Column<string>(type: "text", nullable: true),
                    FaixaSalarial = table.Column<string>(type: "text", nullable: true),
                    Local = table.Column<string>(type: "text", nullable: true),
                    Beneficios = table.Column<int>(type: "integer", nullable: false),
                    OutrosRequisitos = table.Column<string>(type: "text", nullable: true),
                    UsuarioCriacao = table.Column<string>(type: "text", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "text", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vagas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Idiomas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdVaga = table.Column<Guid>(type: "uuid", nullable: false),
                    NomeIdioma = table.Column<string>(type: "text", nullable: true),
                    Nivel = table.Column<string>(type: "text", nullable: true),
                    UsuarioCriacao = table.Column<string>(type: "text", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "text", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idiomas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Idiomas_Vagas_IdVaga",
                        column: x => x.IdVaga,
                        principalTable: "Vagas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uuid", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    TipoContato = table.Column<int>(type: "integer", nullable: false),
                    UsuarioCriacao = table.Column<string>(type: "text", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "text", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Denuncias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdVaga = table.Column<Guid>(type: "uuid", nullable: false),
                    IdPerfilPj = table.Column<Guid>(type: "uuid", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    TipoDencuncia = table.Column<int>(type: "integer", nullable: false),
                    UsuarioCriacao = table.Column<string>(type: "text", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "text", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denuncias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Denuncias_Vagas_IdVaga",
                        column: x => x.IdVaga,
                        principalTable: "Vagas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uuid", nullable: false),
                    Logradouro = table.Column<string>(type: "text", nullable: true),
                    Complemento = table.Column<string>(type: "text", nullable: true),
                    Cep = table.Column<string>(type: "text", nullable: true),
                    Uf = table.Column<string>(type: "text", nullable: true),
                    Pais = table.Column<string>(type: "text", nullable: true),
                    TipoEndereco = table.Column<int>(type: "integer", nullable: false),
                    UsuarioCriacao = table.Column<string>(type: "text", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "text", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uuid", nullable: false),
                    NomeUsuario = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    UsuarioCriacao = table.Column<string>(type: "text", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "text", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PerfilPf",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uuid", nullable: false),
                    CargoDesejado = table.Column<string>(type: "text", nullable: true),
                    AreasDesejads = table.Column<string>(type: "text", nullable: true),
                    PretensaoSalarial = table.Column<int>(type: "integer", nullable: false),
                    ResumoProfissional = table.Column<string>(type: "text", nullable: true),
                    InformacoesComplementares = table.Column<string>(type: "text", nullable: true),
                    Escolaridade = table.Column<string>(type: "text", nullable: true),
                    UsuarioCriacao = table.Column<string>(type: "text", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "text", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilPf", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PerfilPj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uuid", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Avaliacao = table.Column<float>(type: "real", nullable: false),
                    TempoMedioResposta = table.Column<int>(type: "integer", nullable: false),
                    UsuarioCriacao = table.Column<string>(type: "text", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "text", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilPj", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdPerfil = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLogin = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    CpfCnpj = table.Column<string>(type: "text", nullable: true),
                    UsuarioCriacao = table.Column<string>(type: "text", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "text", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Logins_IdLogin",
                        column: x => x.IdLogin,
                        principalTable: "Logins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_PerfilPf_IdPerfil",
                        column: x => x.IdPerfil,
                        principalTable: "PerfilPf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_PerfilPj_IdPerfil",
                        column: x => x.IdPerfil,
                        principalTable: "PerfilPj",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VagasUsuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdVaga = table.Column<Guid>(type: "uuid", nullable: false),
                    IdPerfilPf = table.Column<Guid>(type: "uuid", nullable: false),
                    IdPerfilPj = table.Column<Guid>(type: "uuid", nullable: false),
                    DataEnvioPerfilPf = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataRespostaPerfilPj = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioCriacao = table.Column<string>(type: "text", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "text", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VagasUsuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VagasUsuarios_PerfilPf_IdPerfilPf",
                        column: x => x.IdPerfilPf,
                        principalTable: "PerfilPf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VagasUsuarios_PerfilPj_IdPerfilPj",
                        column: x => x.IdPerfilPj,
                        principalTable: "PerfilPj",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VagasUsuarios_Vagas_IdVaga",
                        column: x => x.IdVaga,
                        principalTable: "Vagas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_IdUsuario",
                table: "Contatos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncias_IdPerfilPj",
                table: "Denuncias",
                column: "IdPerfilPj");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncias_IdVaga",
                table: "Denuncias",
                column: "IdVaga");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_IdUsuario",
                table: "Enderecos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Idiomas_IdVaga",
                table: "Idiomas",
                column: "IdVaga");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_IdUsuario",
                table: "Logins",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PerfilPf_IdUsuario",
                table: "PerfilPf",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PerfilPj_IdUsuario",
                table: "PerfilPj",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdLogin",
                table: "Usuarios",
                column: "IdLogin",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdPerfil",
                table: "Usuarios",
                column: "IdPerfil",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VagasUsuarios_IdPerfilPf",
                table: "VagasUsuarios",
                column: "IdPerfilPf");

            migrationBuilder.CreateIndex(
                name: "IX_VagasUsuarios_IdPerfilPj",
                table: "VagasUsuarios",
                column: "IdPerfilPj");

            migrationBuilder.CreateIndex(
                name: "IX_VagasUsuarios_IdVaga",
                table: "VagasUsuarios",
                column: "IdVaga");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Usuarios_IdUsuario",
                table: "Contatos",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Denuncias_PerfilPj_IdPerfilPj",
                table: "Denuncias",
                column: "IdPerfilPj",
                principalTable: "PerfilPj",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Usuarios_IdUsuario",
                table: "Enderecos",
                column: "IdUsuario",
                principalTable: "Usuarios",
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
                name: "FK_PerfilPf_Usuarios_IdUsuario",
                table: "PerfilPf",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PerfilPj_Usuarios_IdUsuario",
                table: "PerfilPj",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logins_Usuarios_IdUsuario",
                table: "Logins");

            migrationBuilder.DropForeignKey(
                name: "FK_PerfilPf_Usuarios_IdUsuario",
                table: "PerfilPf");

            migrationBuilder.DropForeignKey(
                name: "FK_PerfilPj_Usuarios_IdUsuario",
                table: "PerfilPj");

            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "Denuncias");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Idiomas");

            migrationBuilder.DropTable(
                name: "VagasUsuarios");

            migrationBuilder.DropTable(
                name: "Vagas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "PerfilPf");

            migrationBuilder.DropTable(
                name: "PerfilPj");
        }
    }
}
