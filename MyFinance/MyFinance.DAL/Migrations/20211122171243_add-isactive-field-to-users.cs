using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFinance.DAL.Migrations
{
    public partial class addisactivefieldtousers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsActive", "LastName", "Login", "Password", "Phone" },
                values: new object[] { 1L, "test@test.com", "Administrator", true, null, "admin", "1234", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");
        }
    }
}
