using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFinance.DAL.Migrations
{
    public partial class Initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "finance");

            migrationBuilder.CreateTable(
                name: "Currencies",
                schema: "finance",
                columns: table => new
                {
                    Type = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    IsBase = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(5,4)", nullable: false, defaultValue: 1m),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Type);
                });

            migrationBuilder.CreateTable(
                name: "Budgets",
                schema: "finance",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    CurrencyType = table.Column<string>(type: "nvarchar(4)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Budgets_Currencies_CurrencyType",
                        column: x => x.CurrencyType,
                        principalSchema: "finance",
                        principalTable: "Currencies",
                        principalColumn: "Type",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                schema: "finance",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    BudgetId = table.Column<long>(type: "bigint", nullable: false),
                    CurrencyType = table.Column<string>(type: "nvarchar(4)", nullable: true),
                    LastTransaction = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalSchema: "finance",
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_Currencies_CurrencyType",
                        column: x => x.CurrencyType,
                        principalSchema: "finance",
                        principalTable: "Currencies",
                        principalColumn: "Type",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                schema: "finance",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    ValidThru = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastTransaction = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => new { x.Name, x.AccountId });
                    table.ForeignKey(
                        name: "FK_Cards_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "finance",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "finance",
                table: "Currencies",
                columns: new[] { "Type", "CreatedAt", "CreatedBy", "IsBase", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "BYN", null, null, true, "Белорусский рубль", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_BudgetId",
                schema: "finance",
                table: "Accounts",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CurrencyType",
                schema: "finance",
                table: "Accounts",
                column: "CurrencyType");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_CurrencyType",
                schema: "finance",
                table: "Budgets",
                column: "CurrencyType");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_AccountId",
                schema: "finance",
                table: "Cards",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "Accounts",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "Budgets",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "Currencies",
                schema: "finance");
        }
    }
}
