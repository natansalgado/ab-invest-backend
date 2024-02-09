using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AB_INVEST.Migrations
{
    public partial class UpdateDatesDefaultValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "WithdrawDate",
                table: "Withdraws",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 9, 17, 6, 14, 582, DateTimeKind.Local).AddTicks(5217));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "UsersInvestments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 9, 17, 6, 14, 582, DateTimeKind.Local).AddTicks(3409));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Transfers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 9, 17, 6, 14, 582, DateTimeKind.Local).AddTicks(1266));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "WithdrawDate",
                table: "Withdraws",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 9, 17, 6, 14, 582, DateTimeKind.Local).AddTicks(5217),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "UsersInvestments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 9, 17, 6, 14, 582, DateTimeKind.Local).AddTicks(3409),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Transfers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 9, 17, 6, 14, 582, DateTimeKind.Local).AddTicks(1266),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
