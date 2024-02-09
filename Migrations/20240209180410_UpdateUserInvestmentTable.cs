using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AB_INVEST.Migrations
{
    public partial class UpdateUserInvestmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "UserInvestments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 9, 15, 4, 10, 156, DateTimeKind.Local).AddTicks(4814),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 9, 14, 16, 36, 905, DateTimeKind.Local).AddTicks(9623));

            migrationBuilder.AddColumn<decimal>(
                name: "InitialValue",
                table: "UserInvestments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Transfers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 9, 15, 4, 10, 156, DateTimeKind.Local).AddTicks(2114),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 9, 14, 16, 36, 905, DateTimeKind.Local).AddTicks(7132));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InitialValue",
                table: "UserInvestments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "UserInvestments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 9, 14, 16, 36, 905, DateTimeKind.Local).AddTicks(9623),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 9, 15, 4, 10, 156, DateTimeKind.Local).AddTicks(4814));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Transfers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 9, 14, 16, 36, 905, DateTimeKind.Local).AddTicks(7132),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 9, 15, 4, 10, 156, DateTimeKind.Local).AddTicks(2114));
        }
    }
}
