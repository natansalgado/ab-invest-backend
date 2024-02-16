using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AB_INVEST.Migrations
{
    public partial class AddNameToUsersInvestments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValueWithdrew",
                table: "Withdraws",
                newName: "WithdrewValue");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UsersInvestments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "UsersInvestments");

            migrationBuilder.RenameColumn(
                name: "WithdrewValue",
                table: "Withdraws",
                newName: "ValueWithdrew");
        }
    }
}
