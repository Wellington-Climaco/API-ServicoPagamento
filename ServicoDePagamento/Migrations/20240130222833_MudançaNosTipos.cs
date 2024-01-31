using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicoDePagamento.Migrations
{
    /// <inheritdoc />
    public partial class MudançaNosTipos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Saldo",
                table: "Cliente",
                type: "MONEY",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "FLOAT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Saldo",
                table: "Cliente",
                type: "FLOAT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "MONEY");
        }
    }
}
