using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountManager.Data.Migrations
{
    public partial class AddConcurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AccountType",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Account",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AccountType");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Account");
        }
    }
}
