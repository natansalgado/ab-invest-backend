using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AB_INVEST.Migrations
{
    public partial class CreateUserInvestmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Transfers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 9, 14, 16, 36, 905, DateTimeKind.Local).AddTicks(7132),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 16, 52, 2, 632, DateTimeKind.Local).AddTicks(3029));

            migrationBuilder.CreateTable(
                name: "UserInvestments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    InvestmentId = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 2, 9, 14, 16, 36, 905, DateTimeKind.Local).AddTicks(9623)),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInvestments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInvestments_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserInvestments_Investments_InvestmentId",
                        column: x => x.InvestmentId,
                        principalTable: "Investments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInvestments_AccountId",
                table: "UserInvestments",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInvestments_Id",
                table: "UserInvestments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserInvestments_InvestmentId",
                table: "UserInvestments",
                column: "InvestmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInvestments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Transfers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 16, 52, 2, 632, DateTimeKind.Local).AddTicks(3029),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 9, 14, 16, 36, 905, DateTimeKind.Local).AddTicks(7132));
        }
    }
}
