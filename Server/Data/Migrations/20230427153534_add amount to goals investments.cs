using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Madeni.Server.Data.Migrations
{
    public partial class addamounttogoalsinvestments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Investments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Goals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Investments");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Goals");
        }
    }
}
