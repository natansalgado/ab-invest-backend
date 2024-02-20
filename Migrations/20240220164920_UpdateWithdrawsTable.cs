using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AB_INVEST.Migrations
{
    public partial class UpdateWithdrawsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WithdrewAll",
                table: "Withdraws");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Deposits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 20, 13, 49, 19, 845, DateTimeKind.Local).AddTicks(2442),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 20, 10, 42, 12, 292, DateTimeKind.Local).AddTicks(2442));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "WithdrewAll",
                table: "Withdraws",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Deposits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 20, 10, 42, 12, 292, DateTimeKind.Local).AddTicks(2442),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 20, 13, 49, 19, 845, DateTimeKind.Local).AddTicks(2442));
        }
    }
}
