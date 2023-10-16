using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandySquad.Migrations
{
    /// <inheritdoc />
    public partial class addedrating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfRatings",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "Ratings",
                table: "Profiles",
                newName: "NumberOfUserThatHasRated");

            migrationBuilder.AddColumn<double>(
                name: "TotalRatings",
                table: "Profiles",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalRatings",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "NumberOfUserThatHasRated",
                table: "Profiles",
                newName: "Ratings");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRatings",
                table: "Profiles",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
