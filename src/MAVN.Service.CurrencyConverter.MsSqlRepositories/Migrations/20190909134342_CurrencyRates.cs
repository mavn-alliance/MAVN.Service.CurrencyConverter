using Microsoft.EntityFrameworkCore.Migrations;

namespace MAVN.Service.CurrencyConverter.MsSqlRepositories.Migrations
{
    public partial class CurrencyRates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "currency_rates",
                schema: "currency",
                columns: table => new
                {
                    base_asset = table.Column<string>(nullable: false),
                    quote_asset = table.Column<string>(nullable: false),
                    rate_asset = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currency_rates", x => new { x.base_asset, x.quote_asset });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "currency_rates",
                schema: "currency");
        }
    }
}
