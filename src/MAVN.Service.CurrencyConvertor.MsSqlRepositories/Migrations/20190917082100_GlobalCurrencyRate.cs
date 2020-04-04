using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lykke.Service.CurrencyConvertor.MsSqlRepositories.Migrations
{
    public partial class GlobalCurrencyRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "rate_asset",
                schema: "currency",
                table: "currency_rates",
                newName: "rate");

            migrationBuilder.CreateTable(
                name: "global_currency_rates",
                schema: "currency",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    amount_in_tokens = table.Column<long>(nullable: false),
                    amount_in_currency = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_global_currency_rates", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "global_currency_rates",
                schema: "currency");

            migrationBuilder.RenameColumn(
                name: "rate",
                schema: "currency",
                table: "currency_rates",
                newName: "rate_asset");
        }
    }
}
