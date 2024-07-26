using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoulKingWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOTPAndRefreshTokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OneTimePassword_Users_UserId",
                table: "OneTimePassword");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_Users_UserId",
                table: "RefreshToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshToken",
                table: "RefreshToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OneTimePassword",
                table: "OneTimePassword");

            migrationBuilder.RenameTable(
                name: "RefreshToken",
                newName: "Tokens");

            migrationBuilder.RenameTable(
                name: "OneTimePassword",
                newName: "OTPs");

            migrationBuilder.RenameIndex(
                name: "IX_RefreshToken_UserId",
                table: "Tokens",
                newName: "IX_Tokens_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OneTimePassword_UserId",
                table: "OTPs",
                newName: "IX_OTPs_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tokens",
                table: "Tokens",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OTPs",
                table: "OTPs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OTPs_Users_UserId",
                table: "OTPs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_Users_UserId",
                table: "Tokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OTPs_Users_UserId",
                table: "OTPs");

            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_Users_UserId",
                table: "Tokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tokens",
                table: "Tokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OTPs",
                table: "OTPs");

            migrationBuilder.RenameTable(
                name: "Tokens",
                newName: "RefreshToken");

            migrationBuilder.RenameTable(
                name: "OTPs",
                newName: "OneTimePassword");

            migrationBuilder.RenameIndex(
                name: "IX_Tokens_UserId",
                table: "RefreshToken",
                newName: "IX_RefreshToken_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OTPs_UserId",
                table: "OneTimePassword",
                newName: "IX_OneTimePassword_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshToken",
                table: "RefreshToken",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OneTimePassword",
                table: "OneTimePassword",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OneTimePassword_Users_UserId",
                table: "OneTimePassword",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_Users_UserId",
                table: "RefreshToken",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
