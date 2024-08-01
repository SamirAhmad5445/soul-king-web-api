using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SoulKingWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCatigoriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Categories_CategoryId",
                table: "Songs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Songs_CategoryId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "CategiryId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Songs");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategiryId",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Rock" },
                    { 2, "Pop" },
                    { 3, "Jazz" },
                    { 4, "Hip-hop" },
                    { 5, "Classical" },
                    { 6, "Electronic" },
                    { 7, "Country" },
                    { 8, "Blues" },
                    { 9, "Reggae" },
                    { 10, "Metal" },
                    { 11, "K-pop" },
                    { 12, "Rap" },
                    { 13, "J-pop" },
                    { 14, "Latin" },
                    { 15, "Funk" },
                    { 16, "Soul" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Songs_CategoryId",
                table: "Songs",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Categories_CategoryId",
                table: "Songs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
