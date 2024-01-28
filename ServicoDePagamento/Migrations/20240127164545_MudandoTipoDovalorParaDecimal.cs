using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicoDePagamento.Migrations
{
    /// <inheritdoc />
    public partial class MudandoTipoDovalorParaDecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Transacao",
                type: "DECIMAL(18,0)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "FLOAT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Valor",
                table: "Transacao",
                type: "FLOAT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,0)");
        }
    }
}
