using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AB_INVEST.Migrations
{
    public partial class UpdateUsersInvestmentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInvestments_Accounts_AccountId",
                table: "UserInvestments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInvestments_Investments_InvestmentId",
                table: "UserInvestments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInvestments",
                table: "UserInvestments");

            migrationBuilder.RenameTable(
                name: "UserInvestments",
                newName: "UsersInvestments");

            migrationBuilder.RenameIndex(
                name: "IX_UserInvestments_InvestmentId",
                table: "UsersInvestments",
                newName: "IX_UsersInvestments_InvestmentId");

            migrationBuilder.RenameIndex(
                name: "IX_UserInvestments_Id",
                table: "UsersInvestments",
                newName: "IX_UsersInvestments_Id");

            migrationBuilder.RenameIndex(
                name: "IX_UserInvestments_AccountId",
                table: "UsersInvestments",
                newName: "IX_UsersInvestments_AccountId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "WithdrawDate",
                table: "Withdraws",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 9, 17, 6, 14, 582, DateTimeKind.Local).AddTicks(5217),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 9, 17, 4, 0, 949, DateTimeKind.Local).AddTicks(3974));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Transfers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 9, 17, 6, 14, 582, DateTimeKind.Local).AddTicks(1266),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 9, 17, 4, 0, 948, DateTimeKind.Local).AddTicks(9850));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "UsersInvestments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 9, 17, 6, 14, 582, DateTimeKind.Local).AddTicks(3409),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 9, 17, 4, 0, 949, DateTimeKind.Local).AddTicks(2006));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersInvestments",
                table: "UsersInvestments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInvestments_Accounts_AccountId",
                table: "UsersInvestments",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInvestments_Investments_InvestmentId",
                table: "UsersInvestments",
                column: "InvestmentId",
                principalTable: "Investments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersInvestments_Accounts_AccountId",
                table: "UsersInvestments");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInvestments_Investments_InvestmentId",
                table: "UsersInvestments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersInvestments",
                table: "UsersInvestments");

            migrationBuilder.RenameTable(
                name: "UsersInvestments",
                newName: "UserInvestments");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInvestments_InvestmentId",
                table: "UserInvestments",
                newName: "IX_UserInvestments_InvestmentId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInvestments_Id",
                table: "UserInvestments",
                newName: "IX_UserInvestments_Id");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInvestments_AccountId",
                table: "UserInvestments",
                newName: "IX_UserInvestments_AccountId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "WithdrawDate",
                table: "Withdraws",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 9, 17, 4, 0, 949, DateTimeKind.Local).AddTicks(3974),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 9, 17, 6, 14, 582, DateTimeKind.Local).AddTicks(5217));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Transfers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 9, 17, 4, 0, 948, DateTimeKind.Local).AddTicks(9850),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 9, 17, 6, 14, 582, DateTimeKind.Local).AddTicks(1266));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "UserInvestments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 9, 17, 4, 0, 949, DateTimeKind.Local).AddTicks(2006),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 9, 17, 6, 14, 582, DateTimeKind.Local).AddTicks(3409));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInvestments",
                table: "UserInvestments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInvestments_Accounts_AccountId",
                table: "UserInvestments",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInvestments_Investments_InvestmentId",
                table: "UserInvestments",
                column: "InvestmentId",
                principalTable: "Investments",
                principalColumn: "Id");
        }
    }
}
