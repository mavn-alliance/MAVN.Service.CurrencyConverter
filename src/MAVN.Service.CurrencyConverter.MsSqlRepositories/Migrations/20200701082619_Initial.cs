using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MAVN.Service.CurrencyConverter.MsSqlRepositories.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "currency");

            migrationBuilder.CreateTable(
                name: "currency_rates",
                schema: "currency",
                columns: table => new
                {
                    base_asset = table.Column<string>(nullable: false),
                    quote_asset = table.Column<string>(nullable: false),
                    rate = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currency_rates", x => new { x.base_asset, x.quote_asset });
                });

            migrationBuilder.CreateTable(
                name: "global_currency_rates",
                schema: "currency",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    amount_in_tokens = table.Column<string>(nullable: false),
                    amount_in_currency = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_global_currency_rates", x => x.id);
                });

            migrationBuilder.InsertData(
                schema: "currency",
                table: "currency_rates",
                columns: new[] { "base_asset", "quote_asset", "rate" },
                values: new object[] { "AED", "USD", 0.3061m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "currency_rates",
                schema: "currency");

            migrationBuilder.DropTable(
                name: "global_currency_rates",
                schema: "currency");
        }
    }
}
