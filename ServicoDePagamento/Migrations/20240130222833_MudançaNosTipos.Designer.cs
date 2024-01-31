﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServicoDePagamento.Data;

#nullable disable

namespace ServicoDePagamento.Migrations
{
    [DbContext(typeof(ServicoDbContexto))]
    [Migration("20240130222833_MudançaNosTipos")]
    partial class MudançaNosTipos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ServicoDePagamento.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("CEP");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Documento");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Nome");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("MONEY")
                        .HasColumnName("Saldo");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Documento" }, "IX_Cliente_Documento")
                        .IsUnique();

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("ServicoDePagamento.Models.Recebiveis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataPagamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATE")
                        .HasColumnName("DataPagamento")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<double>("Taxa")
                        .HasMaxLength(100)
                        .HasColumnType("FLOAT")
                        .HasColumnName("Taxa");

                    b.Property<int>("TransacaoId")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("TransacaoId")
                        .IsUnique();

                    b.ToTable("Recebiveis", (string)null);
                });

            modelBuilder.Entity("ServicoDePagamento.Models.Transacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CVV")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("CCV");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Descricao");

                    b.Property<string>("MetodoPagamento")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("MetodoPagamento");

                    b.Property<string>("NumeroCartao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("NumeroCartao");

                    b.Property<string>("ValidadeCartao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("ValidadeCartao");

                    b.Property<decimal>("Valor")
                        .HasColumnType("MONEY")
                        .HasColumnName("Valor");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Transacao", (string)null);
                });

            modelBuilder.Entity("ServicoDePagamento.Models.Recebiveis", b =>
                {
                    b.HasOne("ServicoDePagamento.Models.Cliente", "Cliente")
                        .WithMany("Recebiveis")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Recebiveis_Cliente");

                    b.HasOne("ServicoDePagamento.Models.Transacao", "Transacao")
                        .WithOne("Recebivel")
                        .HasForeignKey("ServicoDePagamento.Models.Recebiveis", "TransacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Recebiveis_Transacao");

                    b.Navigation("Cliente");

                    b.Navigation("Transacao");
                });

            modelBuilder.Entity("ServicoDePagamento.Models.Transacao", b =>
                {
                    b.HasOne("ServicoDePagamento.Models.Cliente", "Cliente")
                        .WithMany("Transacoes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Transacao_Cliente");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("ServicoDePagamento.Models.Cliente", b =>
                {
                    b.Navigation("Recebiveis");

                    b.Navigation("Transacoes");
                });

            modelBuilder.Entity("ServicoDePagamento.Models.Transacao", b =>
                {
                    b.Navigation("Recebivel")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
