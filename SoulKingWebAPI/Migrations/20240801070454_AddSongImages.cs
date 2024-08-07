﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoulKingWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddSongImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 96, 232, 165, 33, 212, 216, 159, 37, 145, 233, 75, 196, 179, 231, 106, 57, 243, 118, 62, 226, 55, 216, 118, 19, 143, 193, 159, 52, 238, 85, 112, 136, 53, 242, 12, 239, 33, 102, 120, 119, 229, 213, 1, 16, 81, 123, 162, 152, 95, 162, 199, 249, 71, 211, 99, 206, 155, 201, 22, 172, 61, 55, 232, 4 }, new byte[] { 165, 88, 116, 134, 92, 231, 102, 167, 111, 99, 223, 42, 196, 178, 16, 65, 35, 208, 97, 87, 190, 244, 244, 149, 31, 60, 120, 111, 128, 87, 82, 156, 184, 28, 248, 219, 253, 64, 58, 72, 48, 123, 241, 5, 92, 75, 120, 32, 4, 143, 104, 186, 104, 17, 204, 240, 226, 87, 157, 21, 227, 133, 47, 29, 51, 102, 13, 140, 51, 109, 57, 224, 174, 158, 251, 50, 123, 221, 9, 160, 28, 233, 214, 222, 16, 13, 147, 152, 41, 62, 64, 253, 29, 111, 210, 17, 21, 225, 114, 140, 103, 60, 218, 32, 129, 156, 46, 28, 241, 41, 37, 223, 152, 217, 184, 60, 204, 15, 164, 14, 34, 198, 201, 99, 164, 177, 42, 241 } });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 38, 43, 187, 41, 92, 153, 242, 18, 20, 36, 120, 66, 34, 194, 246, 139, 248, 10, 156, 35, 74, 189, 177, 129, 124, 185, 157, 185, 234, 254, 67, 106, 77, 235, 39, 110, 61, 36, 101, 95, 187, 93, 30, 187, 166, 170, 248, 103, 145, 0, 64, 86, 81, 140, 99, 197, 209, 16, 160, 228, 153, 167, 23, 150 }, new byte[] { 151, 76, 253, 92, 46, 71, 173, 172, 101, 224, 55, 163, 29, 112, 140, 8, 124, 136, 25, 236, 19, 94, 84, 137, 236, 236, 229, 177, 60, 230, 218, 205, 72, 205, 206, 148, 2, 64, 105, 142, 223, 120, 101, 86, 6, 194, 192, 67, 143, 144, 148, 213, 238, 215, 52, 232, 42, 228, 94, 115, 84, 73, 6, 150, 50, 137, 198, 43, 118, 120, 84, 115, 90, 137, 63, 99, 161, 144, 212, 26, 95, 92, 44, 22, 22, 65, 15, 71, 125, 200, 92, 83, 62, 189, 229, 100, 80, 230, 174, 255, 64, 45, 228, 99, 249, 115, 77, 192, 181, 49, 22, 238, 211, 242, 49, 103, 192, 190, 150, 51, 226, 33, 92, 209, 255, 25, 138, 73 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Songs");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 156, 150, 4, 185, 89, 3, 111, 33, 169, 136, 9, 191, 159, 140, 54, 78, 240, 80, 227, 26, 223, 39, 194, 87, 58, 178, 84, 47, 154, 34, 174, 208, 48, 82, 203, 28, 104, 26, 181, 184, 85, 209, 26, 181, 252, 146, 249, 133, 238, 177, 151, 138, 243, 98, 107, 201, 11, 140, 229, 125, 176, 196, 90, 64 }, new byte[] { 97, 203, 247, 245, 20, 188, 31, 166, 25, 89, 122, 63, 64, 212, 151, 242, 106, 169, 108, 161, 68, 65, 222, 16, 121, 235, 169, 119, 51, 43, 193, 25, 148, 43, 217, 63, 99, 118, 245, 34, 23, 196, 95, 153, 78, 10, 135, 222, 27, 238, 87, 243, 109, 111, 119, 28, 133, 241, 188, 147, 123, 100, 187, 210, 56, 246, 198, 180, 99, 128, 168, 238, 222, 27, 220, 217, 110, 25, 42, 253, 41, 136, 36, 27, 180, 72, 178, 214, 200, 194, 3, 57, 173, 144, 118, 85, 41, 119, 101, 106, 21, 60, 3, 95, 79, 189, 156, 145, 217, 57, 187, 174, 92, 88, 245, 41, 70, 20, 157, 5, 35, 125, 95, 156, 81, 91, 190, 4 } });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 165, 244, 179, 227, 66, 223, 79, 30, 96, 162, 167, 249, 214, 150, 78, 250, 209, 95, 240, 106, 188, 109, 164, 197, 230, 178, 202, 161, 197, 72, 177, 252, 29, 20, 110, 50, 141, 116, 3, 183, 167, 112, 33, 3, 31, 237, 179, 16, 124, 25, 89, 238, 250, 246, 60, 44, 242, 101, 191, 251, 134, 155, 62, 172 }, new byte[] { 189, 101, 153, 152, 5, 120, 77, 136, 155, 16, 224, 238, 98, 46, 23, 115, 211, 29, 205, 119, 70, 174, 226, 140, 186, 32, 176, 106, 169, 145, 174, 68, 79, 116, 221, 4, 191, 87, 71, 156, 192, 195, 246, 37, 246, 32, 86, 201, 4, 204, 156, 152, 20, 49, 120, 99, 103, 252, 253, 2, 133, 181, 26, 119, 36, 65, 239, 202, 90, 170, 222, 142, 125, 37, 230, 11, 21, 219, 206, 151, 183, 149, 56, 76, 151, 89, 227, 75, 160, 114, 62, 29, 191, 227, 160, 100, 90, 205, 190, 4, 149, 64, 180, 242, 235, 74, 224, 49, 211, 125, 158, 215, 14, 205, 201, 117, 21, 213, 48, 1, 75, 219, 28, 196, 163, 189, 26, 192 } });
        }
    }
}
