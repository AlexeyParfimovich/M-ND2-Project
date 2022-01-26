using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFinance.DAL.Migrations
{
    public partial class updateuserentitymigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Budgets_Users_UserId",
                schema: "finance",
                table: "Budgets");

            migrationBuilder.DropIndex(
                name: "IX_Budgets_UserId",
                schema: "finance",
                table: "Budgets");

            migrationBuilder.DeleteData(
                schema: "finance",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("49478411-92f0-4c3a-9c7e-69e7b2bbe8e7"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "finance",
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Email", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[] { new Guid("49478411-92f0-4c3a-9c7e-69e7b2bbe8e7"), null, null, "admin@test.by", null, null, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_UserId",
                schema: "finance",
                table: "Budgets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Budgets_Users_UserId",
                schema: "finance",
                table: "Budgets",
                column: "UserId",
                principalSchema: "finance",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
