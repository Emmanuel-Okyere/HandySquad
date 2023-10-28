using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HandySquad.Migrations
{
    /// <inheritdoc />
    public partial class dealMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "deal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AmountTobePaid = table.Column<double>(type: "double precision", nullable: false),
                    AcceptedByArtisan = table.Column<bool>(type: "boolean", nullable: false),
                    AcceptedByClient = table.Column<bool>(type: "boolean", nullable: false),
                    ClientId = table.Column<int>(type: "integer", nullable: true),
                    ArtisanId = table.Column<int>(type: "integer", nullable: true),
                    WorkStatusUpdateByClient = table.Column<bool>(type: "boolean", nullable: false),
                    WorkStatusUpdateByArtisan = table.Column<bool>(type: "boolean", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ExpectedEndDateByClient = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_deal_users_ArtisanId",
                        column: x => x.ArtisanId,
                        principalTable: "users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_deal_users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_deal_ArtisanId",
                table: "deal",
                column: "ArtisanId");

            migrationBuilder.CreateIndex(
                name: "IX_deal_ClientId",
                table: "deal",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "deal");
        }
    }
}
