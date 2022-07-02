using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Madeni.Server.Data.Migrations
{
    public partial class adduseridtotables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("DELETE FROM Repayments");
            migrationBuilder.Sql("DELETE FROM Loans");
            migrationBuilder.Sql("DELETE FROM Expenses");
            migrationBuilder.Sql("DELETE FROM Incomes");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Repayments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Loans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Incomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Repayments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Expenses");
        }
    }
}
