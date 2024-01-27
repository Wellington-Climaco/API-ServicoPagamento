using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicoDePagamento.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoNoDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ValidadeCartao",
                table: "Transacao",
                type: "VARCHAR",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME");

            migrationBuilder.AddColumn<double>(
                name: "Valor",
                table: "Transacao",
                type: "FLOAT",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Transacao");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValidadeCartao",
                table: "Transacao",
                type: "SMALLDATETIME",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR");
        }
    }
}
