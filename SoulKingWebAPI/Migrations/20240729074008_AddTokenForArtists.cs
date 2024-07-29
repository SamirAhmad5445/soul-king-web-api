using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoulKingWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTokenForArtists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "Artists");
        }
    }
}
