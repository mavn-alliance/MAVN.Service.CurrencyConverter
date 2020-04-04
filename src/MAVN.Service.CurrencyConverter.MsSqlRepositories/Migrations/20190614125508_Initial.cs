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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "currency",
                schema: "currency");
        }
    }
}
