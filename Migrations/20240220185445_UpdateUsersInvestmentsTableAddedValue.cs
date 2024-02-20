using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AB_INVEST.Migrations
{
    public partial class UpdateUsersInvestmentsTableAddedValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AddedValue",
                table: "UsersInvestments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Deposits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 20, 15, 54, 45, 315, DateTimeKind.Local).AddTicks(178),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 20, 13, 49, 19, 845, DateTimeKind.Local).AddTicks(2442));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedValue",
                table: "UsersInvestments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Deposits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 20, 13, 49, 19, 845, DateTimeKind.Local).AddTicks(2442),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 20, 15, 54, 45, 315, DateTimeKind.Local).AddTicks(178));
        }
    }
}
