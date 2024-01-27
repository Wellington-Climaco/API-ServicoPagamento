using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicoDePagamento.Migrations
{
    /// <inheritdoc />
    public partial class CriandoDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Documento = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Saldo = table.Column<double>(type: "FLOAT", nullable: false),
                    CEP = table.Column<string>(type: "VARCHAR", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    MetodoPagamento = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    NumeroCartao = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    ValidadeCartao = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    CCV = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacao_Cliente",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recebiveis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    Taxa = table.Column<double>(type: "FLOAT", maxLength: 100, nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    TransacaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recebiveis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recebiveis_Cliente",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recebiveis_Transacao",
                        column: x => x.TransacaoId,
                        principalTable: "Transacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Documento",
                table: "Cliente",
                column: "Documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recebiveis_ClienteId",
                table: "Recebiveis",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Recebiveis_TransacaoId",
                table: "Recebiveis",
                column: "TransacaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_ClienteId",
                table: "Transacao",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recebiveis");

            migrationBuilder.DropTable(
                name: "Transacao");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
