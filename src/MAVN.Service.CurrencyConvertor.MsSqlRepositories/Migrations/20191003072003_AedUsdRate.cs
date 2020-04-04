using Microsoft.EntityFrameworkCore.Migrations;

namespace Lykke.Service.CurrencyConvertor.MsSqlRepositories.Migrations
{
    public partial class AedUsdRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "currency",
                table: "currency_rates",
                columns: new[] { "base_asset", "quote_asset", "rate" },
                values: new object[] { "AED", "USD", 0.3061m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "currency",
                table: "currency_rates",
                keyColumns: new[] { "base_asset", "quote_asset" },
                keyValues: new object[] { "AED", "USD" });
        }
    }
}
