using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFinance.DAL.Migrations
{
    public partial class Modifyuserentitymigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "finance",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7cc9ded4-cb29-468d-a143-5048772a8b27"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "finance",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "finance",
                table: "Users");

            migrationBuilder.InsertData(
                schema: "finance",
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Email", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[] { new Guid("49478411-92f0-4c3a-9c7e-69e7b2bbe8e7"), null, null, "admin@test.by", null, null, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "finance",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("49478411-92f0-4c3a-9c7e-69e7b2bbe8e7"));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "finance",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "finance",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.InsertData(
                schema: "finance",
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Email", "FirstName", "LastName", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[] { new Guid("7cc9ded4-cb29-468d-a143-5048772a8b27"), null, null, "test@test.by", "Test", "Testov", null, null, "TestUser" });
        }
    }
}
