using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFinance.DAL.Migrations
{
    public partial class Add_IsMainCurrency_field_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMainCurrency",
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
                column: "IsMainCurrency",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMainCurrency",
                schema: "finance",
                table: "Currencies");
        }
    }
}
