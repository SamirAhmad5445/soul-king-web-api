using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoulKingWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialArtist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "BirthDate", "Description", "DisplayName", "Email", "FirstName", "FollowersCount", "IsActivated", "LastName", "PasswordHash", "PasswordSalt", "Token", "Username" },
                values: new object[] { 1, new DateOnly(1974, 4, 13), "A musician and swordsman who is also a skeleton.", "Sk Brook", "sk.brook@strawhats.com", "Soul King", 0, false, "Brook", new byte[] { 154, 166, 139, 205, 10, 166, 188, 105, 212, 60, 69, 33, 191, 85, 154, 76, 223, 196, 239, 107, 51, 151, 70, 112, 65, 87, 172, 82, 52, 145, 168, 11, 100, 141, 214, 18, 25, 204, 176, 211, 83, 82, 119, 54, 149, 81, 45, 136, 175, 143, 81, 121, 109, 252, 140, 179, 172, 166, 27, 90, 158, 109, 232, 100 }, new byte[] { 104, 248, 147, 93, 162, 213, 87, 3, 78, 28, 132, 215, 111, 212, 20, 141, 163, 79, 251, 239, 245, 134, 208, 10, 243, 83, 192, 14, 78, 23, 169, 8, 158, 199, 215, 186, 1, 223, 255, 1, 20, 207, 166, 241, 161, 104, 178, 103, 238, 24, 131, 132, 197, 85, 239, 88, 228, 28, 149, 88, 75, 60, 70, 215, 209, 2, 191, 207, 251, 125, 38, 146, 104, 138, 48, 225, 128, 51, 50, 51, 72, 176, 128, 174, 47, 102, 148, 253, 153, 150, 33, 73, 249, 172, 14, 130, 220, 126, 5, 255, 112, 111, 208, 123, 152, 144, 18, 70, 15, 85, 163, 179, 202, 228, 174, 253, 34, 211, 151, 255, 182, 190, 3, 122, 175, 159, 104, 135 }, "", "brook" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
