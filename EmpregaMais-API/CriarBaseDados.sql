CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Vagas" (
    "Id" uuid NOT NULL,
    "Titulo" text NULL,
    "Descricao" text NULL,
    "DataExpiracao" timestamp with time zone NOT NULL,
    "NivelSenioridade" text NULL,
    "FaixaSalarial" text NULL,
    "Local" text NULL,
    "Beneficios" integer NOT NULL,
    "OutrosRequisitos" text NULL,
    "UsuarioCriacao" text NULL,
    "DataCriacao" timestamp with time zone NOT NULL,
    "UsuarioAlteracao" text NULL,
    "DataAlteracao" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Vagas" PRIMARY KEY ("Id")
);

CREATE TABLE "Idiomas" (
    "Id" uuid NOT NULL,
    "IdVaga" uuid NOT NULL,
    "NomeIdioma" text NULL,
    "Nivel" text NULL,
    "UsuarioCriacao" text NULL,
    "DataCriacao" timestamp with time zone NOT NULL,
    "UsuarioAlteracao" text NULL,
    "DataAlteracao" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Idiomas" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Idiomas_Vagas_IdVaga" FOREIGN KEY ("IdVaga") REFERENCES "Vagas" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Contatos" (
    "Id" uuid NOT NULL,
    "IdUsuario" uuid NOT NULL,
    "Descricao" text NULL,
    "TipoContato" integer NOT NULL,
    "UsuarioCriacao" text NULL,
    "DataCriacao" timestamp with time zone NOT NULL,
    "UsuarioAlteracao" text NULL,
    "DataAlteracao" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Contatos" PRIMARY KEY ("Id")
);

CREATE TABLE "Denuncias" (
    "Id" uuid NOT NULL,
    "IdVaga" uuid NOT NULL,
    "IdPerfilPj" uuid NOT NULL,
    "Descricao" text NULL,
    "TipoDencuncia" integer NOT NULL,
    "UsuarioCriacao" text NULL,
    "DataCriacao" timestamp with time zone NOT NULL,
    "UsuarioAlteracao" text NULL,
    "DataAlteracao" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Denuncias" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Denuncias_Vagas_IdVaga" FOREIGN KEY ("IdVaga") REFERENCES "Vagas" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Enderecos" (
    "Id" uuid NOT NULL,
    "IdUsuario" uuid NOT NULL,
    "Logradouro" text NULL,
    "Complemento" text NULL,
    "Cep" text NULL,
    "Uf" text NULL,
    "Pais" text NULL,
    "TipoEndereco" integer NOT NULL,
    "UsuarioCriacao" text NULL,
    "DataCriacao" timestamp with time zone NOT NULL,
    "UsuarioAlteracao" text NULL,
    "DataAlteracao" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Enderecos" PRIMARY KEY ("Id")
);

CREATE TABLE "Logins" (
    "Id" uuid NOT NULL,
    "IdUsuario" uuid NOT NULL,
    "NomeUsuario" text NULL,
    "Password" text NULL,
    "UsuarioCriacao" text NULL,
    "DataCriacao" timestamp with time zone NOT NULL,
    "UsuarioAlteracao" text NULL,
    "DataAlteracao" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Logins" PRIMARY KEY ("Id")
);

CREATE TABLE "PerfilPf" (
    "Id" uuid NOT NULL,
    "IdUsuario" uuid NOT NULL,
    "CargoDesejado" text NULL,
    "AreasDesejads" text NULL,
    "PretensaoSalarial" integer NOT NULL,
    "ResumoProfissional" text NULL,
    "InformacoesComplementares" text NULL,
    "Escolaridade" text NULL,
    "UsuarioCriacao" text NULL,
    "DataCriacao" timestamp with time zone NOT NULL,
    "UsuarioAlteracao" text NULL,
    "DataAlteracao" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_PerfilPf" PRIMARY KEY ("Id")
);

CREATE TABLE "PerfilPj" (
    "Id" uuid NOT NULL,
    "IdUsuario" uuid NOT NULL,
    "Descricao" text NULL,
    "Avaliacao" real NOT NULL,
    "TempoMedioResposta" integer NOT NULL,
    "UsuarioCriacao" text NULL,
    "DataCriacao" timestamp with time zone NOT NULL,
    "UsuarioAlteracao" text NULL,
    "DataAlteracao" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_PerfilPj" PRIMARY KEY ("Id")
);

CREATE TABLE "Usuarios" (
    "Id" uuid NOT NULL,
    "IdPerfil" uuid NOT NULL,
    "IdLogin" uuid NOT NULL,
    "Nome" text NULL,
    "CpfCnpj" text NULL,
    "UsuarioCriacao" text NULL,
    "DataCriacao" timestamp with time zone NOT NULL,
    "UsuarioAlteracao" text NULL,
    "DataAlteracao" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Usuarios" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Usuarios_Logins_IdLogin" FOREIGN KEY ("IdLogin") REFERENCES "Logins" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Usuarios_PerfilPf_IdPerfil" FOREIGN KEY ("IdPerfil") REFERENCES "PerfilPf" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Usuarios_PerfilPj_IdPerfil" FOREIGN KEY ("IdPerfil") REFERENCES "PerfilPj" ("Id") ON DELETE CASCADE
);

CREATE TABLE "VagasUsuarios" (
    "Id" uuid NOT NULL,
    "IdVaga" uuid NOT NULL,
    "IdPerfilPf" uuid NOT NULL,
    "IdPerfilPj" uuid NOT NULL,
    "DataEnvioPerfilPf" timestamp with time zone NOT NULL,
    "DataRespostaPerfilPj" timestamp with time zone NOT NULL,
    "UsuarioCriacao" text NULL,
    "DataCriacao" timestamp with time zone NOT NULL,
    "UsuarioAlteracao" text NULL,
    "DataAlteracao" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_VagasUsuarios" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_VagasUsuarios_PerfilPf_IdPerfilPf" FOREIGN KEY ("IdPerfilPf") REFERENCES "PerfilPf" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_VagasUsuarios_PerfilPj_IdPerfilPj" FOREIGN KEY ("IdPerfilPj") REFERENCES "PerfilPj" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_VagasUsuarios_Vagas_IdVaga" FOREIGN KEY ("IdVaga") REFERENCES "Vagas" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Contatos_IdUsuario" ON "Contatos" ("IdUsuario");

CREATE INDEX "IX_Denuncias_IdPerfilPj" ON "Denuncias" ("IdPerfilPj");

CREATE INDEX "IX_Denuncias_IdVaga" ON "Denuncias" ("IdVaga");

CREATE INDEX "IX_Enderecos_IdUsuario" ON "Enderecos" ("IdUsuario");

CREATE INDEX "IX_Idiomas_IdVaga" ON "Idiomas" ("IdVaga");

CREATE UNIQUE INDEX "IX_Logins_IdUsuario" ON "Logins" ("IdUsuario");

CREATE UNIQUE INDEX "IX_PerfilPf_IdUsuario" ON "PerfilPf" ("IdUsuario");

CREATE UNIQUE INDEX "IX_PerfilPj_IdUsuario" ON "PerfilPj" ("IdUsuario");

CREATE UNIQUE INDEX "IX_Usuarios_IdLogin" ON "Usuarios" ("IdLogin");

CREATE UNIQUE INDEX "IX_Usuarios_IdPerfil" ON "Usuarios" ("IdPerfil");

CREATE INDEX "IX_VagasUsuarios_IdPerfilPf" ON "VagasUsuarios" ("IdPerfilPf");

CREATE INDEX "IX_VagasUsuarios_IdPerfilPj" ON "VagasUsuarios" ("IdPerfilPj");

CREATE INDEX "IX_VagasUsuarios_IdVaga" ON "VagasUsuarios" ("IdVaga");

ALTER TABLE "Contatos" ADD CONSTRAINT "FK_Contatos_Usuarios_IdUsuario" FOREIGN KEY ("IdUsuario") REFERENCES "Usuarios" ("Id") ON DELETE CASCADE;

ALTER TABLE "Denuncias" ADD CONSTRAINT "FK_Denuncias_PerfilPj_IdPerfilPj" FOREIGN KEY ("IdPerfilPj") REFERENCES "PerfilPj" ("Id") ON DELETE CASCADE;

ALTER TABLE "Enderecos" ADD CONSTRAINT "FK_Enderecos_Usuarios_IdUsuario" FOREIGN KEY ("IdUsuario") REFERENCES "Usuarios" ("Id") ON DELETE CASCADE;

ALTER TABLE "Logins" ADD CONSTRAINT "FK_Logins_Usuarios_IdUsuario" FOREIGN KEY ("IdUsuario") REFERENCES "Usuarios" ("Id") ON DELETE CASCADE;

ALTER TABLE "PerfilPf" ADD CONSTRAINT "FK_PerfilPf_Usuarios_IdUsuario" FOREIGN KEY ("IdUsuario") REFERENCES "Usuarios" ("Id") ON DELETE CASCADE;

ALTER TABLE "PerfilPj" ADD CONSTRAINT "FK_PerfilPj_Usuarios_IdUsuario" FOREIGN KEY ("IdUsuario") REFERENCES "Usuarios" ("Id") ON DELETE CASCADE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221109232201_InitialCreate', '7.0.0');

COMMIT;

START TRANSACTION;

ALTER TABLE "Denuncias" DROP CONSTRAINT "FK_Denuncias_PerfilPj_IdPerfilPj";

ALTER TABLE "Denuncias" DROP CONSTRAINT "FK_Denuncias_Vagas_IdVaga";

ALTER TABLE "Usuarios" DROP CONSTRAINT "FK_Usuarios_PerfilPf_IdPerfil";

ALTER TABLE "Usuarios" DROP CONSTRAINT "FK_Usuarios_PerfilPj_IdPerfil";

ALTER TABLE "VagasUsuarios" DROP CONSTRAINT "FK_VagasUsuarios_PerfilPf_IdPerfilPf";

ALTER TABLE "VagasUsuarios" DROP CONSTRAINT "FK_VagasUsuarios_PerfilPj_IdPerfilPj";

ALTER TABLE "VagasUsuarios" ALTER COLUMN "IdPerfilPj" DROP NOT NULL;

ALTER TABLE "VagasUsuarios" ALTER COLUMN "IdPerfilPf" DROP NOT NULL;

UPDATE "Logins" SET "Password" = '' WHERE "Password" IS NULL;
ALTER TABLE "Logins" ALTER COLUMN "Password" SET NOT NULL;
ALTER TABLE "Logins" ALTER COLUMN "Password" SET DEFAULT '';

UPDATE "Logins" SET "NomeUsuario" = '' WHERE "NomeUsuario" IS NULL;
ALTER TABLE "Logins" ALTER COLUMN "NomeUsuario" SET NOT NULL;
ALTER TABLE "Logins" ALTER COLUMN "NomeUsuario" SET DEFAULT '';

ALTER TABLE "Logins" ALTER COLUMN "IdUsuario" DROP NOT NULL;

ALTER TABLE "Denuncias" ALTER COLUMN "IdVaga" DROP NOT NULL;

ALTER TABLE "Denuncias" ALTER COLUMN "IdPerfilPj" DROP NOT NULL;

ALTER TABLE "Denuncias" ADD CONSTRAINT "FK_Denuncias_PerfilPj_IdPerfilPj" FOREIGN KEY ("IdPerfilPj") REFERENCES "PerfilPj" ("Id");

ALTER TABLE "Denuncias" ADD CONSTRAINT "FK_Denuncias_Vagas_IdVaga" FOREIGN KEY ("IdVaga") REFERENCES "Vagas" ("Id");

ALTER TABLE "Logins" ADD CONSTRAINT "FK_Logins_Usuarios_IdUsuario" FOREIGN KEY ("IdUsuario") REFERENCES "Usuarios" ("Id");

ALTER TABLE "Usuarios" ADD CONSTRAINT "FK_Usuarios_PerfilPf_IdPerfil" FOREIGN KEY ("IdPerfil") REFERENCES "PerfilPf" ("Id");

ALTER TABLE "Usuarios" ADD CONSTRAINT "FK_Usuarios_PerfilPj_IdPerfil" FOREIGN KEY ("IdPerfil") REFERENCES "PerfilPj" ("Id");

ALTER TABLE "VagasUsuarios" ADD CONSTRAINT "FK_VagasUsuarios_PerfilPf_IdPerfilPf" FOREIGN KEY ("IdPerfilPf") REFERENCES "PerfilPf" ("Id");

ALTER TABLE "VagasUsuarios" ADD CONSTRAINT "FK_VagasUsuarios_PerfilPj_IdPerfilPj" FOREIGN KEY ("IdPerfilPj") REFERENCES "PerfilPj" ("Id");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221111222120_AjusteRelacoes', '7.0.0');

COMMIT;

START TRANSACTION;

ALTER TABLE "Usuarios" ALTER COLUMN "IdPerfil" DROP NOT NULL;

ALTER TABLE "Denuncias" DROP CONSTRAINT "FK_Denuncias_PerfilPj_IdPerfilPj";

ALTER TABLE "Denuncias" DROP CONSTRAINT "FK_Denuncias_Vagas_IdVaga";

ALTER TABLE "Usuarios" DROP CONSTRAINT "FK_Usuarios_PerfilPf_IdPerfil";

ALTER TABLE "Usuarios" DROP CONSTRAINT "FK_Usuarios_PerfilPj_IdPerfil";

ALTER TABLE "VagasUsuarios" DROP CONSTRAINT "FK_VagasUsuarios_PerfilPf_IdPerfilPf";

ALTER TABLE "VagasUsuarios" DROP CONSTRAINT "FK_VagasUsuarios_PerfilPj_IdPerfilPj";

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221111223042_AjustesFK', '7.0.0');

COMMIT;

START TRANSACTION;

ALTER TABLE "Logins" DROP CONSTRAINT "FK_Logins_Usuarios_IdUsuario";

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221111223320_AjusteLogin', '7.0.0');

COMMIT;

START TRANSACTION;

CREATE TABLE "HistoricosAcademicos" (
    "Id" uuid NOT NULL,
    "IdPerfil" uuid NOT NULL,
    "NivelEscolaridade" integer NOT NULL,
    "NomeInstituicao" text NOT NULL,
    "NomeCurso" text NOT NULL,
    "DataInicio" timestamp with time zone NOT NULL,
    "DataConclusao" timestamp with time zone NOT NULL,
    "Cursando" boolean NOT NULL,
    "UsuarioCriacao" text NULL,
    "DataCriacao" timestamp with time zone NOT NULL,
    "UsuarioAlteracao" text NULL,
    "DataAlteracao" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_HistoricosAcademicos" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_HistoricosAcademicos_PerfilPf_IdPerfil" FOREIGN KEY ("IdPerfil") REFERENCES "PerfilPf" ("Id") ON DELETE CASCADE
);

CREATE TABLE "HistoricosProfissionais" (
    "Id" uuid NOT NULL,
    "IdPerfil" uuid NOT NULL,
    "NomeEmpresa" text NOT NULL,
    "Cargo" text NOT NULL,
    "DescricaoFuncoes" text NOT NULL,
    "DataEntrada" timestamp with time zone NOT NULL,
    "DataSaida" timestamp with time zone NULL,
    "EmpresaAtual" boolean NOT NULL,
    "UsuarioCriacao" text NULL,
    "DataCriacao" timestamp with time zone NOT NULL,
    "UsuarioAlteracao" text NULL,
    "DataAlteracao" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_HistoricosProfissionais" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_HistoricosProfissionais_PerfilPf_IdPerfil" FOREIGN KEY ("IdPerfil") REFERENCES "PerfilPf" ("Id") ON DELETE CASCADE
);

CREATE TABLE "RedesSociais" (
    "Id" uuid NOT NULL,
    "IdPerfil" uuid NOT NULL,
    "Nome" text NOT NULL,
    "Link" text NOT NULL,
    "UsuarioCriacao" text NULL,
    "DataCriacao" timestamp with time zone NOT NULL,
    "UsuarioAlteracao" text NULL,
    "DataAlteracao" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_RedesSociais" PRIMARY KEY ("Id")
);

CREATE INDEX "IX_HistoricosAcademicos_IdPerfil" ON "HistoricosAcademicos" ("IdPerfil");

CREATE INDEX "IX_HistoricosProfissionais_IdPerfil" ON "HistoricosProfissionais" ("IdPerfil");

CREATE INDEX "IX_RedesSociais_IdPerfil" ON "RedesSociais" ("IdPerfil");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221111234718_DadosPerfil', '7.0.0');

COMMIT;

START TRANSACTION;

DROP INDEX "IX_VagasUsuarios_IdPerfilPj";

ALTER TABLE "VagasUsuarios" DROP COLUMN "IdPerfilPj";

ALTER TABLE "Vagas" ADD "IdPerfil" uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';

CREATE INDEX "IX_Vagas_IdPerfil" ON "Vagas" ("IdPerfil");

ALTER TABLE "Vagas" ADD CONSTRAINT "FK_Vagas_PerfilPj_IdPerfil" FOREIGN KEY ("IdPerfil") REFERENCES "PerfilPj" ("Id") ON DELETE CASCADE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221112000641_AjusteVagas', '7.0.0');

COMMIT;

START TRANSACTION;

ALTER TABLE "Contatos" DROP CONSTRAINT "FK_Contatos_Usuarios_IdUsuario";

ALTER TABLE "Enderecos" DROP CONSTRAINT "FK_Enderecos_Usuarios_IdUsuario";

ALTER TABLE "Usuarios" DROP CONSTRAINT "FK_Usuarios_Logins_IdLogin";

ALTER TABLE "Usuarios" ALTER COLUMN "IdLogin" DROP NOT NULL;

ALTER TABLE "Usuarios" ADD "TipoUsuario" integer NOT NULL DEFAULT 0;

ALTER TABLE "Enderecos" ALTER COLUMN "IdUsuario" DROP NOT NULL;

ALTER TABLE "Contatos" ALTER COLUMN "IdUsuario" DROP NOT NULL;

ALTER TABLE "Contatos" ADD CONSTRAINT "FK_Contatos_Usuarios_IdUsuario" FOREIGN KEY ("IdUsuario") REFERENCES "Usuarios" ("Id");

ALTER TABLE "Enderecos" ADD CONSTRAINT "FK_Enderecos_Usuarios_IdUsuario" FOREIGN KEY ("IdUsuario") REFERENCES "Usuarios" ("Id");

ALTER TABLE "Usuarios" ADD CONSTRAINT "FK_Usuarios_Logins_IdLogin" FOREIGN KEY ("IdLogin") REFERENCES "Logins" ("Id");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221112141453_AjusteUsuario', '7.0.0');

COMMIT;

START TRANSACTION;

DROP INDEX "IX_Enderecos_IdUsuario";

ALTER TABLE "Vagas" ADD "VagaAtiva" boolean NOT NULL DEFAULT FALSE;

CREATE UNIQUE INDEX "IX_Enderecos_IdUsuario" ON "Enderecos" ("IdUsuario");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221121231401_AtualizacaoVagaModel', '7.0.0');

COMMIT;

START TRANSACTION;

ALTER TABLE "PerfilPf" DROP COLUMN "AreasDesejads";

ALTER TABLE "HistoricosProfissionais" ALTER COLUMN "NomeEmpresa" DROP NOT NULL;

ALTER TABLE "HistoricosProfissionais" ALTER COLUMN "EmpresaAtual" DROP NOT NULL;

ALTER TABLE "HistoricosProfissionais" ALTER COLUMN "DescricaoFuncoes" DROP NOT NULL;

ALTER TABLE "HistoricosProfissionais" ALTER COLUMN "DataEntrada" DROP NOT NULL;

ALTER TABLE "HistoricosProfissionais" ALTER COLUMN "Cargo" DROP NOT NULL;

ALTER TABLE "HistoricosAcademicos" ALTER COLUMN "NomeInstituicao" DROP NOT NULL;

ALTER TABLE "HistoricosAcademicos" ALTER COLUMN "NomeCurso" DROP NOT NULL;

ALTER TABLE "HistoricosAcademicos" ALTER COLUMN "DataInicio" DROP NOT NULL;

ALTER TABLE "HistoricosAcademicos" ALTER COLUMN "DataConclusao" DROP NOT NULL;

ALTER TABLE "HistoricosAcademicos" ALTER COLUMN "Cursando" DROP NOT NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221126182622_AtualizacaoHistoricos', '7.0.0');

COMMIT;

START TRANSACTION;

UPDATE "HistoricosProfissionais" SET "DataEntrada" = TIMESTAMPTZ '-infinity' WHERE "DataEntrada" IS NULL;
ALTER TABLE "HistoricosProfissionais" ALTER COLUMN "DataEntrada" SET NOT NULL;
ALTER TABLE "HistoricosProfissionais" ALTER COLUMN "DataEntrada" SET DEFAULT TIMESTAMPTZ '-infinity';

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221129003928_FinalMigration', '7.0.0');

COMMIT;

