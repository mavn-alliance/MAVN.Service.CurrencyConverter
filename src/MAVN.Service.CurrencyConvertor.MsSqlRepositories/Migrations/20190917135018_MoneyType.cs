using Microsoft.EntityFrameworkCore.Migrations;

namespace Lykke.Service.CurrencyConvertor.MsSqlRepositories.Migrations
{
    public partial class MoneyType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "currency",
                schema: "currency");

            migrationBuilder.AlterColumn<string>(
                name: "amount_in_tokens",
                schema: "currency",
                table: "global_currency_rates",
                type: "nvarchar(64)",
                nullable: false,
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "amount_in_tokens",
                schema: "currency",
                table: "global_currency_rates",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldNullable: false);

            migrationBuilder.CreateTable(
                name: "currency",
                schema: "currency",
                columns: table => new
                {
                    currency_code = table.Column<string>(type: "varchar(64)", nullable: false),
                    currency_label = table.Column<string>(nullable: true),
                    currency_rate = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currency", x => x.currency_code);
                });
        }
    }
}
