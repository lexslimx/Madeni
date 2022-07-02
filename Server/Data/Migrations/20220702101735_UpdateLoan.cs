using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Madeni.Server.Data.Migrations
{
    public partial class UpdateLoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartSate",
                table: "Loans");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProspectiveDate",
                table: "Loans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Loans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Loans");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProspectiveDate",
                table: "Loans",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartSate",
                table: "Loans",
                type: "datetime2",
                nullable: true);
        }
    }
}
