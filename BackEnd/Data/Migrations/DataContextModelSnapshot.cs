﻿// <auto-generated />
using System;
using BackEnd.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEnd.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("BackEnd.Models.AppUsuario", b =>
                {
                    b.Property<int>("usuario_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ConhecidoComo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("DataDeNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Interesses")
                        .HasColumnType("TEXT");

                    b.Property<string>("Introducao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PrimeiroLogin")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProcurandoPor")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("passwordHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("passwordSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("usuario_nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("usuario_sobrenome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("usuario_id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("BackEnd.Models.Foto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AppUsuarioId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsMain")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PublicId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AppUsuarioId");

                    b.ToTable("Fotos");
                });

            modelBuilder.Entity("BackEnd.Models.Foto", b =>
                {
                    b.HasOne("BackEnd.Models.AppUsuario", "AppUsuario")
                        .WithMany("Fotos")
                        .HasForeignKey("AppUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUsuario");
                });

            modelBuilder.Entity("BackEnd.Models.AppUsuario", b =>
                {
                    b.Navigation("Fotos");
                });
#pragma warning restore 612, 618
        }
    }
}
