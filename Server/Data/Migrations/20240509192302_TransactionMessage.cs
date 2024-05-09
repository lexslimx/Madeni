using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Madeni.Server.Data.Migrations
{
    public partial class TransactionMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionMessageId",
                table: "Repayments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionMessageId",
                table: "Incomes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionMessageId",
                table: "Expenses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TransactionMessages",
                columns: table => new
                {
                    TransactionMessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionMessages", x => x.TransactionMessageId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Repayments_TransactionMessageId",
                table: "Repayments",
                column: "TransactionMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_TransactionMessageId",
                table: "Incomes",
                column: "TransactionMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_TransactionMessageId",
                table: "Expenses",
                column: "TransactionMessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_TransactionMessages_TransactionMessageId",
                table: "Expenses",
                column: "TransactionMessageId",
                principalTable: "TransactionMessages",
                principalColumn: "TransactionMessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_TransactionMessages_TransactionMessageId",
                table: "Incomes",
                column: "TransactionMessageId",
                principalTable: "TransactionMessages",
                principalColumn: "TransactionMessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Repayments_TransactionMessages_TransactionMessageId",
                table: "Repayments",
                column: "TransactionMessageId",
                principalTable: "TransactionMessages",
                principalColumn: "TransactionMessageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_TransactionMessages_TransactionMessageId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_TransactionMessages_TransactionMessageId",
                table: "Incomes");

            migrationBuilder.DropForeignKey(
                name: "FK_Repayments_TransactionMessages_TransactionMessageId",
                table: "Repayments");

            migrationBuilder.DropTable(
                name: "TransactionMessages");

            migrationBuilder.DropIndex(
                name: "IX_Repayments_TransactionMessageId",
                table: "Repayments");

            migrationBuilder.DropIndex(
                name: "IX_Incomes_TransactionMessageId",
                table: "Incomes");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_TransactionMessageId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "TransactionMessageId",
                table: "Repayments");

            migrationBuilder.DropColumn(
                name: "TransactionMessageId",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "TransactionMessageId",
                table: "Expenses");
        }
    }
}
