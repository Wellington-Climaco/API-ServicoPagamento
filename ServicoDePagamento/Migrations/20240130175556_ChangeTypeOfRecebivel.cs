using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicoDePagamento.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTypeOfRecebivel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Transacao",
                type: "MONEY",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,0)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPagamento",
                table: "Recebiveis",
                type: "DATE",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValueSql: "GETDATE()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Transacao",
                type: "DECIMAL(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "MONEY");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPagamento",
                table: "Recebiveis",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
