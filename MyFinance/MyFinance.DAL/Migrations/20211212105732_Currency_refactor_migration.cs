using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFinance.DAL.Migrations
{
    public partial class Currency_refactor_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBase",
                schema: "finance",
                table: "Currencies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBase",
                schema: "finance",
                table: "Currencies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "finance",
                table: "Currencies",
                keyColumn: "Id",
                keyValue: "BYN",
                column: "IsBase",
                value: true);
        }
    }
}
