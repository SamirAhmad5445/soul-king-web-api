﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoulKingWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddImagesToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Access",
                table: "Playlists");

            migrationBuilder.AddColumn<string>(
                name: "ProfileImage",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 15, 186, 95, 58, 169, 103, 141, 75, 31, 192, 255, 104, 184, 68, 62, 77, 44, 66, 119, 40, 164, 150, 244, 157, 161, 185, 19, 4, 154, 179, 153, 216, 246, 47, 207, 87, 70, 7, 224, 211, 215, 149, 147, 6, 220, 157, 29, 200, 133, 54, 196, 150, 119, 194, 208, 105, 74, 14, 141, 190, 110, 193, 44, 41 }, new byte[] { 48, 111, 171, 143, 26, 253, 95, 217, 69, 81, 35, 221, 83, 82, 164, 251, 152, 177, 202, 161, 46, 110, 40, 128, 131, 213, 185, 35, 97, 113, 107, 92, 50, 45, 244, 148, 221, 236, 3, 50, 158, 65, 5, 5, 135, 121, 243, 47, 146, 119, 19, 167, 74, 130, 7, 137, 94, 6, 219, 190, 247, 115, 236, 70, 75, 86, 34, 147, 148, 59, 25, 201, 88, 15, 246, 135, 103, 1, 131, 131, 76, 40, 145, 37, 77, 195, 61, 15, 190, 86, 92, 82, 180, 49, 245, 217, 109, 16, 232, 89, 166, 197, 36, 138, 117, 65, 164, 77, 116, 7, 48, 65, 171, 190, 69, 244, 138, 86, 83, 109, 20, 159, 223, 23, 178, 134, 248, 110 } });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 209, 133, 39, 137, 50, 169, 35, 88, 119, 45, 51, 102, 39, 152, 246, 54, 133, 140, 35, 45, 239, 150, 71, 22, 103, 101, 120, 129, 100, 26, 189, 239, 19, 162, 230, 14, 21, 194, 41, 197, 241, 228, 209, 53, 40, 239, 8, 2, 145, 216, 163, 72, 138, 126, 200, 154, 213, 17, 183, 43, 78, 131, 179, 97 }, new byte[] { 102, 22, 95, 246, 7, 244, 10, 144, 74, 238, 93, 53, 43, 152, 134, 116, 49, 180, 219, 159, 126, 23, 110, 72, 75, 168, 158, 180, 59, 46, 56, 253, 24, 237, 199, 155, 1, 250, 240, 142, 174, 133, 255, 95, 97, 9, 154, 90, 248, 254, 90, 54, 93, 112, 8, 54, 73, 159, 68, 188, 22, 139, 127, 162, 233, 26, 170, 245, 129, 167, 29, 29, 101, 249, 77, 118, 206, 59, 154, 16, 206, 138, 23, 158, 220, 98, 56, 26, 83, 133, 17, 206, 245, 75, 13, 9, 145, 50, 115, 235, 66, 230, 122, 242, 125, 46, 23, 116, 148, 193, 9, 110, 200, 197, 15, 46, 31, 199, 47, 209, 61, 101, 191, 237, 200, 197, 194, 179 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Access",
                table: "Playlists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 142, 78, 42, 250, 148, 249, 154, 196, 211, 19, 0, 169, 215, 234, 74, 204, 205, 131, 232, 125, 0, 183, 108, 65, 160, 27, 248, 52, 101, 64, 124, 233, 53, 65, 143, 249, 159, 123, 82, 91, 16, 134, 84, 68, 51, 148, 232, 80, 4, 206, 2, 207, 116, 230, 110, 36, 125, 120, 108, 178, 194, 125, 237, 160 }, new byte[] { 17, 166, 169, 93, 139, 108, 132, 26, 97, 161, 214, 125, 187, 16, 55, 98, 125, 52, 208, 5, 228, 25, 97, 139, 236, 239, 87, 34, 5, 44, 4, 240, 184, 14, 240, 96, 90, 207, 66, 110, 163, 246, 176, 130, 137, 45, 40, 130, 208, 254, 24, 170, 121, 52, 49, 78, 21, 98, 80, 215, 157, 59, 203, 193, 208, 159, 161, 193, 33, 49, 83, 147, 234, 103, 143, 194, 62, 56, 5, 4, 184, 213, 232, 140, 190, 201, 69, 109, 218, 1, 13, 18, 46, 231, 41, 200, 112, 147, 132, 162, 64, 121, 192, 244, 211, 23, 129, 91, 119, 137, 118, 63, 122, 101, 84, 248, 82, 117, 33, 208, 151, 253, 239, 229, 227, 210, 154, 185 } });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 183, 61, 232, 116, 107, 179, 144, 130, 222, 157, 227, 206, 97, 48, 25, 198, 45, 19, 123, 50, 124, 16, 238, 120, 247, 94, 225, 117, 153, 100, 44, 31, 178, 45, 71, 177, 109, 210, 176, 151, 110, 188, 158, 223, 162, 22, 128, 70, 223, 226, 61, 144, 198, 228, 223, 81, 29, 197, 163, 48, 194, 238, 213, 31 }, new byte[] { 96, 250, 77, 44, 175, 128, 72, 0, 194, 148, 254, 98, 40, 135, 222, 46, 168, 41, 50, 191, 8, 119, 16, 116, 97, 157, 215, 189, 213, 51, 30, 163, 4, 15, 102, 136, 173, 247, 123, 64, 252, 228, 76, 10, 117, 25, 157, 46, 220, 74, 71, 44, 178, 238, 226, 76, 253, 63, 115, 100, 235, 63, 4, 92, 41, 205, 199, 61, 172, 186, 203, 97, 58, 161, 191, 15, 146, 138, 47, 118, 107, 122, 102, 79, 232, 171, 190, 126, 102, 145, 121, 85, 65, 217, 127, 142, 191, 18, 179, 132, 130, 117, 241, 195, 227, 73, 2, 236, 125, 139, 186, 113, 147, 3, 104, 43, 135, 70, 170, 170, 127, 77, 66, 168, 10, 125, 99, 10 } });
        }
    }
}
