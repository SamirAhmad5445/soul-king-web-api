using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoulKingWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserSongTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSongs");

            migrationBuilder.AddColumn<int>(
                name: "PlaysCount",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 227, 124, 150, 236, 3, 213, 196, 33, 192, 200, 172, 129, 47, 2, 107, 64, 249, 70, 139, 228, 159, 100, 70, 106, 189, 27, 32, 248, 233, 34, 130, 128, 245, 56, 77, 23, 20, 134, 110, 40, 54, 187, 112, 252, 18, 137, 136, 176, 138, 254, 119, 212, 32, 112, 78, 71, 35, 213, 227, 134, 186, 175, 50, 190 }, new byte[] { 133, 52, 114, 88, 12, 43, 245, 205, 166, 21, 41, 249, 116, 67, 223, 163, 149, 123, 18, 209, 28, 215, 236, 23, 8, 113, 179, 149, 42, 201, 36, 154, 114, 53, 75, 79, 23, 236, 159, 198, 189, 247, 20, 173, 7, 94, 163, 220, 229, 211, 155, 241, 199, 129, 221, 205, 106, 132, 115, 36, 127, 78, 250, 38, 255, 130, 5, 22, 185, 160, 158, 243, 111, 112, 145, 169, 207, 22, 106, 98, 29, 169, 148, 187, 247, 69, 19, 202, 121, 199, 121, 38, 12, 212, 55, 26, 130, 56, 7, 8, 237, 219, 56, 48, 58, 102, 177, 38, 58, 221, 17, 159, 134, 25, 233, 168, 218, 242, 178, 223, 218, 8, 26, 102, 8, 35, 78, 186 } });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 89, 116, 171, 27, 58, 144, 156, 2, 28, 146, 22, 205, 163, 87, 45, 31, 42, 178, 186, 54, 238, 232, 46, 212, 192, 166, 225, 148, 38, 109, 63, 127, 128, 105, 77, 18, 73, 23, 209, 234, 146, 209, 233, 72, 30, 67, 100, 27, 211, 146, 13, 43, 203, 46, 252, 26, 252, 54, 212, 87, 196, 237, 194, 110 }, new byte[] { 7, 129, 91, 254, 189, 101, 212, 143, 119, 130, 86, 4, 38, 100, 16, 251, 9, 105, 35, 243, 38, 42, 42, 191, 195, 148, 20, 169, 14, 250, 71, 225, 255, 142, 162, 17, 228, 49, 37, 203, 125, 72, 232, 81, 242, 114, 206, 16, 247, 44, 125, 119, 160, 3, 186, 214, 188, 15, 101, 122, 46, 74, 73, 194, 122, 248, 224, 118, 230, 246, 154, 45, 15, 184, 6, 111, 83, 241, 230, 25, 58, 173, 180, 132, 14, 116, 173, 54, 64, 173, 94, 179, 4, 219, 119, 194, 85, 134, 148, 84, 138, 132, 109, 217, 168, 211, 244, 119, 176, 85, 40, 236, 27, 106, 82, 44, 177, 171, 58, 7, 54, 211, 134, 183, 203, 224, 92, 12 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlaysCount",
                table: "Songs");

            migrationBuilder.CreateTable(
                name: "UserSongs",
                columns: table => new
                {
                    HeardSongsId = table.Column<int>(type: "int", nullable: false),
                    ListenersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSongs", x => new { x.HeardSongsId, x.ListenersId });
                    table.ForeignKey(
                        name: "FK_UserSongs_Songs_HeardSongsId",
                        column: x => x.HeardSongsId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSongs_Users_ListenersId",
                        column: x => x.ListenersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserSongs_ListenersId",
                table: "UserSongs",
                column: "ListenersId");
        }
    }
}
