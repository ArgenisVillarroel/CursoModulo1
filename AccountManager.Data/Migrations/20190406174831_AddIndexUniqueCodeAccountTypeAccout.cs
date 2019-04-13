using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountManager.Data.Migrations
{
    public partial class AddIndexUniqueCodeAccountTypeAccout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "AccountType",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Account",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountType_Code",
                table: "AccountType",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Account_Code",
                table: "Account",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AccountType_Code",
                table: "AccountType");

            migrationBuilder.DropIndex(
                name: "IX_Account_Code",
                table: "Account");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "AccountType",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Account",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
