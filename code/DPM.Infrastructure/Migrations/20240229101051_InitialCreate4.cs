using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DPM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_fishing_trip_history_fishermens_fishermen_id",
                table: "fishing_trip_history");

            migrationBuilder.AddForeignKey(
                name: "fk_fishing_trip_history_fishermens_fishermen_id",
                table: "fishing_trip_history",
                column: "fishermen_id",
                principalTable: "fishermens",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_fishing_trip_history_fishermens_fishermen_id",
                table: "fishing_trip_history");

            migrationBuilder.AddForeignKey(
                name: "fk_fishing_trip_history_fishermens_fishermen_id",
                table: "fishing_trip_history",
                column: "fishermen_id",
                principalTable: "fishermens",
                principalColumn: "id");
        }
    }
}
