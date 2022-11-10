﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EmpregaMaisAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.Models.ContatoModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uuid");

                    b.Property<int>("TipoContato")
                        .HasColumnType("integer");

                    b.Property<string>("UsuarioAlteracao")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioCriacao")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("Infrastructure.Models.DenunciaModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<Guid>("IdPerfilPj")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdVaga")
                        .HasColumnType("uuid");

                    b.Property<int>("TipoDencuncia")
                        .HasColumnType("integer");

                    b.Property<string>("UsuarioAlteracao")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioCriacao")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdPerfilPj");

                    b.HasIndex("IdVaga");

                    b.ToTable("Denuncias");
                });

            modelBuilder.Entity("Infrastructure.Models.EnderecoModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Cep")
                        .HasColumnType("text");

                    b.Property<string>("Complemento")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uuid");

                    b.Property<string>("Logradouro")
                        .HasColumnType("text");

                    b.Property<string>("Pais")
                        .HasColumnType("text");

                    b.Property<int>("TipoEndereco")
                        .HasColumnType("integer");

                    b.Property<string>("Uf")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioAlteracao")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioCriacao")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Infrastructure.Models.IdiomaModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("IdVaga")
                        .HasColumnType("uuid");

                    b.Property<string>("Nivel")
                        .HasColumnType("text");

                    b.Property<string>("NomeIdioma")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioAlteracao")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioCriacao")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdVaga");

                    b.ToTable("Idiomas");
                });

            modelBuilder.Entity("Infrastructure.Models.LoginModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uuid");

                    b.Property<string>("NomeUsuario")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioAlteracao")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioCriacao")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario")
                        .IsUnique();

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("Infrastructure.Models.PerfilPfModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AreasDesejads")
                        .HasColumnType("text");

                    b.Property<string>("CargoDesejado")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Escolaridade")
                        .HasColumnType("text");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uuid");

                    b.Property<string>("InformacoesComplementares")
                        .HasColumnType("text");

                    b.Property<int>("PretensaoSalarial")
                        .HasColumnType("integer");

                    b.Property<string>("ResumoProfissional")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioAlteracao")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioCriacao")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario")
                        .IsUnique();

                    b.ToTable("PerfilPf");
                });

            modelBuilder.Entity("Infrastructure.Models.PerfilPjModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<float>("Avaliacao")
                        .HasColumnType("real");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uuid");

                    b.Property<int>("TempoMedioResposta")
                        .HasColumnType("integer");

                    b.Property<string>("UsuarioAlteracao")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioCriacao")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario")
                        .IsUnique();

                    b.ToTable("PerfilPj");
                });

            modelBuilder.Entity("Infrastructure.Models.UsuarioModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CpfCnpj")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("IdLogin")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdPerfil")
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioAlteracao")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioCriacao")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdLogin")
                        .IsUnique();

                    b.HasIndex("IdPerfil")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Infrastructure.Models.VagaModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Beneficios")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataExpiracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<string>("FaixaSalarial")
                        .HasColumnType("text");

                    b.Property<string>("Local")
                        .HasColumnType("text");

                    b.Property<string>("NivelSenioridade")
                        .HasColumnType("text");

                    b.Property<string>("OutrosRequisitos")
                        .HasColumnType("text");

                    b.Property<string>("Titulo")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioAlteracao")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioCriacao")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Vagas");
                });

            modelBuilder.Entity("Infrastructure.Models.VagaUsuarioModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataEnvioPerfilPf")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataRespostaPerfilPj")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("IdPerfilPf")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdPerfilPj")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdVaga")
                        .HasColumnType("uuid");

                    b.Property<string>("UsuarioAlteracao")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioCriacao")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdPerfilPf");

                    b.HasIndex("IdPerfilPj");

                    b.HasIndex("IdVaga");

                    b.ToTable("VagasUsuarios");
                });

            modelBuilder.Entity("Infrastructure.Models.ContatoModel", b =>
                {
                    b.HasOne("Infrastructure.Models.UsuarioModel", null)
                        .WithMany("Contatos")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Models.DenunciaModel", b =>
                {
                    b.HasOne("Infrastructure.Models.PerfilPjModel", null)
                        .WithMany("Denuncias")
                        .HasForeignKey("IdPerfilPj")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Models.VagaModel", null)
                        .WithMany("Denuncias")
                        .HasForeignKey("IdVaga")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Models.EnderecoModel", b =>
                {
                    b.HasOne("Infrastructure.Models.UsuarioModel", null)
                        .WithMany("Enderecos")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Models.IdiomaModel", b =>
                {
                    b.HasOne("Infrastructure.Models.VagaModel", null)
                        .WithMany("Idiomas")
                        .HasForeignKey("IdVaga")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Models.LoginModel", b =>
                {
                    b.HasOne("Infrastructure.Models.UsuarioModel", null)
                        .WithOne("Login")
                        .HasForeignKey("Infrastructure.Models.LoginModel", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Models.PerfilPfModel", b =>
                {
                    b.HasOne("Infrastructure.Models.UsuarioModel", null)
                        .WithOne("PerfilPf")
                        .HasForeignKey("Infrastructure.Models.PerfilPfModel", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Models.PerfilPjModel", b =>
                {
                    b.HasOne("Infrastructure.Models.UsuarioModel", null)
                        .WithOne("PerfilPj")
                        .HasForeignKey("Infrastructure.Models.PerfilPjModel", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Models.UsuarioModel", b =>
                {
                    b.HasOne("Infrastructure.Models.LoginModel", null)
                        .WithOne("Usuario")
                        .HasForeignKey("Infrastructure.Models.UsuarioModel", "IdLogin")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Models.PerfilPfModel", null)
                        .WithOne("Usuario")
                        .HasForeignKey("Infrastructure.Models.UsuarioModel", "IdPerfil")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Models.PerfilPjModel", null)
                        .WithOne("Usuario")
                        .HasForeignKey("Infrastructure.Models.UsuarioModel", "IdPerfil")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Models.VagaUsuarioModel", b =>
                {
                    b.HasOne("Infrastructure.Models.PerfilPfModel", null)
                        .WithMany("VagasUsuarios")
                        .HasForeignKey("IdPerfilPf")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Models.PerfilPjModel", null)
                        .WithMany("VagasUsuarios")
                        .HasForeignKey("IdPerfilPj")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Models.VagaModel", null)
                        .WithMany("VagasUsuarios")
                        .HasForeignKey("IdVaga")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Models.LoginModel", b =>
                {
                    b.Navigation("Usuario")
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Models.PerfilPfModel", b =>
                {
                    b.Navigation("Usuario")
                        .IsRequired();

                    b.Navigation("VagasUsuarios");
                });

            modelBuilder.Entity("Infrastructure.Models.PerfilPjModel", b =>
                {
                    b.Navigation("Denuncias");

                    b.Navigation("Usuario")
                        .IsRequired();

                    b.Navigation("VagasUsuarios");
                });

            modelBuilder.Entity("Infrastructure.Models.UsuarioModel", b =>
                {
                    b.Navigation("Contatos");

                    b.Navigation("Enderecos");

                    b.Navigation("Login")
                        .IsRequired();

                    b.Navigation("PerfilPf")
                        .IsRequired();

                    b.Navigation("PerfilPj")
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Models.VagaModel", b =>
                {
                    b.Navigation("Denuncias");

                    b.Navigation("Idiomas");

                    b.Navigation("VagasUsuarios");
                });
#pragma warning restore 612, 618
        }
    }
}