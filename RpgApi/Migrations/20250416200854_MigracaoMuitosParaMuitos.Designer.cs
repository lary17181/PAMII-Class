﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RpgApi.Data;

#nullable disable

namespace RpgApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250416200854_MigracaoMuitosParaMuitos")]
    partial class MigracaoMuitosParaMuitos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RpgApi.Models.Arma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Dano")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.Property<int>("PersonagemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonagemId")
                        .IsUnique();

                    b.ToTable("TB_ARMAS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Dano = 35,
                            Nome = "Arco e Flecha",
                            PersonagemId = 1
                        },
                        new
                        {
                            Id = 2,
                            Dano = 33,
                            Nome = "Espada",
                            PersonagemId = 2
                        },
                        new
                        {
                            Id = 3,
                            Dano = 31,
                            Nome = "Machado",
                            PersonagemId = 3
                        },
                        new
                        {
                            Id = 4,
                            Dano = 30,
                            Nome = "Punho",
                            PersonagemId = 4
                        },
                        new
                        {
                            Id = 5,
                            Dano = 34,
                            Nome = "Chicote",
                            PersonagemId = 5
                        },
                        new
                        {
                            Id = 6,
                            Dano = 33,
                            Nome = "Foice",
                            PersonagemId = 6
                        },
                        new
                        {
                            Id = 7,
                            Dano = 32,
                            Nome = "Cajado",
                            PersonagemId = 7
                        });
                });

            modelBuilder.Entity("RpgApi.Models.Habilidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Dano")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.HasKey("Id");

                    b.ToTable("TB_HABILIDADES", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Dano = 39,
                            Nome = "Adromecer"
                        },
                        new
                        {
                            Id = 2,
                            Dano = 41,
                            Nome = "Congelar"
                        },
                        new
                        {
                            Id = 3,
                            Dano = 37,
                            Nome = "Hipnotizar"
                        });
                });

            modelBuilder.Entity("RpgApi.Models.Personagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Classe")
                        .HasColumnType("int");

                    b.Property<int>("Defesa")
                        .HasColumnType("int");

                    b.Property<int>("Derrotas")
                        .HasColumnType("int");

                    b.Property<int>("Disputas")
                        .HasColumnType("int");

                    b.Property<int>("Forca")
                        .HasColumnType("int");

                    b.Property<byte[]>("FotoPersonagem")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Inteligencia")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.Property<int>("PontosVida")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("Vitorias")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("TB_PERSONAGENS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Classe = 1,
                            Defesa = 23,
                            Derrotas = 0,
                            Disputas = 0,
                            Forca = 17,
                            Inteligencia = 33,
                            Nome = "Frodo",
                            PontosVida = 100,
                            UsuarioId = 1,
                            Vitorias = 0
                        },
                        new
                        {
                            Id = 2,
                            Classe = 1,
                            Defesa = 25,
                            Derrotas = 0,
                            Disputas = 0,
                            Forca = 15,
                            Inteligencia = 30,
                            Nome = "Sam",
                            PontosVida = 100,
                            UsuarioId = 1,
                            Vitorias = 0
                        },
                        new
                        {
                            Id = 3,
                            Classe = 3,
                            Defesa = 21,
                            Derrotas = 0,
                            Disputas = 0,
                            Forca = 18,
                            Inteligencia = 35,
                            Nome = "Galadriel",
                            PontosVida = 100,
                            UsuarioId = 1,
                            Vitorias = 0
                        },
                        new
                        {
                            Id = 4,
                            Classe = 2,
                            Defesa = 18,
                            Derrotas = 0,
                            Disputas = 0,
                            Forca = 18,
                            Inteligencia = 37,
                            Nome = "Gandalf",
                            PontosVida = 100,
                            UsuarioId = 1,
                            Vitorias = 0
                        },
                        new
                        {
                            Id = 5,
                            Classe = 1,
                            Defesa = 17,
                            Derrotas = 0,
                            Disputas = 0,
                            Forca = 20,
                            Inteligencia = 31,
                            Nome = "Hobbit",
                            PontosVida = 100,
                            UsuarioId = 1,
                            Vitorias = 0
                        },
                        new
                        {
                            Id = 6,
                            Classe = 3,
                            Defesa = 13,
                            Derrotas = 0,
                            Disputas = 0,
                            Forca = 21,
                            Inteligencia = 34,
                            Nome = "Celeborn",
                            PontosVida = 100,
                            UsuarioId = 1,
                            Vitorias = 0
                        },
                        new
                        {
                            Id = 7,
                            Classe = 2,
                            Defesa = 11,
                            Derrotas = 0,
                            Disputas = 0,
                            Forca = 25,
                            Inteligencia = 35,
                            Nome = "Radagast",
                            PontosVida = 100,
                            UsuarioId = 1,
                            Vitorias = 0
                        });
                });

            modelBuilder.Entity("RpgApi.Models.PersonagemHabilidade", b =>
                {
                    b.Property<int>("PersonagemId")
                        .HasColumnType("int");

                    b.Property<int>("HabilidadeId")
                        .HasColumnType("int");

                    b.HasKey("PersonagemId", "HabilidadeId");

                    b.HasIndex("HabilidadeId");

                    b.ToTable("TB_PERSONAGENS_HABILIDADES", (string)null);

                    b.HasData(
                        new
                        {
                            PersonagemId = 1,
                            HabilidadeId = 1
                        },
                        new
                        {
                            PersonagemId = 1,
                            HabilidadeId = 2
                        },
                        new
                        {
                            PersonagemId = 2,
                            HabilidadeId = 2
                        },
                        new
                        {
                            PersonagemId = 3,
                            HabilidadeId = 2
                        },
                        new
                        {
                            PersonagemId = 3,
                            HabilidadeId = 3
                        },
                        new
                        {
                            PersonagemId = 4,
                            HabilidadeId = 3
                        },
                        new
                        {
                            PersonagemId = 5,
                            HabilidadeId = 1
                        },
                        new
                        {
                            PersonagemId = 6,
                            HabilidadeId = 2
                        },
                        new
                        {
                            PersonagemId = 7,
                            HabilidadeId = 3
                        });
                });

            modelBuilder.Entity("RpgApi.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAcesso")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Perfil")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar")
                        .HasDefaultValue("jogador");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.HasKey("Id");

                    b.ToTable("TB_USUARIOS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "seuEmail@gmail.com",
                            Latitude = -23.520024100000001,
                            Longitude = -46.596497999999997,
                            PasswordHash = new byte[] { 34, 7, 89, 100, 88, 203, 80, 101, 255, 9, 210, 129, 234, 148, 88, 145, 223, 235, 207, 202, 191, 202, 217, 73, 99, 140, 112, 127, 163, 83, 71, 139, 70, 214, 79, 41, 178, 136, 71, 102, 61, 224, 135, 105, 83, 189, 208, 41, 174, 149, 116, 104, 241, 31, 50, 49, 255, 152, 247, 94, 69, 67, 201, 66 },
                            PasswordSalt = new byte[] { 55, 59, 249, 81, 99, 105, 96, 82, 15, 54, 7, 251, 72, 33, 233, 123, 236, 254, 197, 235, 3, 138, 122, 178, 30, 254, 33, 141, 76, 29, 3, 105, 224, 111, 49, 212, 181, 116, 14, 226, 164, 186, 78, 8, 113, 48, 27, 212, 200, 246, 60, 125, 43, 81, 84, 76, 160, 185, 154, 75, 161, 114, 228, 66, 150, 101, 236, 225, 192, 101, 134, 17, 75, 222, 181, 139, 57, 146, 200, 131, 26, 158, 150, 69, 162, 193, 3, 184, 73, 171, 87, 228, 222, 89, 244, 222, 6, 130, 195, 252, 143, 81, 21, 129, 254, 195, 165, 20, 114, 203, 219, 171, 79, 93, 57, 148, 159, 238, 36, 125, 5, 223, 185, 134, 105, 92, 233, 166 },
                            Perfil = "Admin",
                            Username = "UsuarioAdmin"
                        });
                });

            modelBuilder.Entity("RpgApi.Models.Arma", b =>
                {
                    b.HasOne("RpgApi.Models.Personagem", "Personagem")
                        .WithOne("Arma")
                        .HasForeignKey("RpgApi.Models.Arma", "PersonagemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personagem");
                });

            modelBuilder.Entity("RpgApi.Models.Personagem", b =>
                {
                    b.HasOne("RpgApi.Models.Usuario", "Usuario")
                        .WithMany("Personagens")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("RpgApi.Models.PersonagemHabilidade", b =>
                {
                    b.HasOne("RpgApi.Models.Habilidade", "Habilidade")
                        .WithMany("PersonagemHabilidades")
                        .HasForeignKey("HabilidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RpgApi.Models.Personagem", "Personagem")
                        .WithMany("PersonagemHabilidades")
                        .HasForeignKey("PersonagemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Habilidade");

                    b.Navigation("Personagem");
                });

            modelBuilder.Entity("RpgApi.Models.Habilidade", b =>
                {
                    b.Navigation("PersonagemHabilidades");
                });

            modelBuilder.Entity("RpgApi.Models.Personagem", b =>
                {
                    b.Navigation("Arma");

                    b.Navigation("PersonagemHabilidades");
                });

            modelBuilder.Entity("RpgApi.Models.Usuario", b =>
                {
                    b.Navigation("Personagens");
                });
#pragma warning restore 612, 618
        }
    }
}
