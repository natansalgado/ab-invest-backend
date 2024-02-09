using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AB_INVEST.Migrations
{
    public partial class CreateWithdrawTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "UserInvestments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 9, 16, 47, 44, 445, DateTimeKind.Local).AddTicks(472),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 9, 15, 4, 10, 156, DateTimeKind.Local).AddTicks(4814));

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
                oldDefaultValue: new DateTime(2024, 2, 9, 15, 4, 10, 156, DateTimeKind.Local).AddTicks(2114));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2024, 2, 9, 15, 4, 10, 156, DateTimeKind.Local).AddTicks(4814),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 9, 16, 47, 44, 445, DateTimeKind.Local).AddTicks(472));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Transfers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 9, 15, 4, 10, 156, DateTimeKind.Local).AddTicks(2114),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 9, 16, 47, 44, 444, DateTimeKind.Local).AddTicks(8186));
        }
    }
}
