using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AB_INVEST.Migrations
{
    public partial class UpdateWithDrawTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "UserInvestments");

            migrationBuilder.DropColumn(
                name: "WithdrawDate",
                table: "UserInvestments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "UserInvestments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 9, 17, 4, 0, 949, DateTimeKind.Local).AddTicks(2006),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 9, 16, 47, 44, 445, DateTimeKind.Local).AddTicks(472));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Transfers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 9, 17, 4, 0, 948, DateTimeKind.Local).AddTicks(9850),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 9, 16, 47, 44, 444, DateTimeKind.Local).AddTicks(8186));

            migrationBuilder.CreateTable(
                name: "Withdraws",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InitialValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    InvestmentId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WithdrawDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 2, 9, 17, 4, 0, 949, DateTimeKind.Local).AddTicks(3974))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Withdraws", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Withdraws_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Withdraws_Investments_InvestmentId",
                        column: x => x.InvestmentId,
                        principalTable: "Investments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Withdraws_AccountId",
                table: "Withdraws",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Withdraws_Id",
                table: "Withdraws",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Withdraws_InvestmentId",
                table: "Withdraws",
                column: "InvestmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Withdraws");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "UserInvestments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 9, 16, 47, 44, 445, DateTimeKind.Local).AddTicks(472),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 9, 17, 4, 0, 949, DateTimeKind.Local).AddTicks(2006));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "UserInvestments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "WithdrawDate",
                table: "UserInvestments",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 9, 16, 47, 44, 445, DateTimeKind.Local).AddTicks(2338));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Transfers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 9, 16, 47, 44, 444, DateTimeKind.Local).AddTicks(8186),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 9, 17, 4, 0, 948, DateTimeKind.Local).AddTicks(9850));
        }
    }
}
