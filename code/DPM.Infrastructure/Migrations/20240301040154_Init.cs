using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DPM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_fishing_trip_history_fishermens_fishermen_id",
                table: "fishing_trip_history");

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "users",
                type: "varchar(16)",
                nullable: false,
                defaultValue: "None");

            migrationBuilder.AddForeignKey(
                name: "fk_fishing_trip_history_fishermens_fishermen_id",
                table: "fishing_trip_history",
                column: "fishermen_id",
                principalTable: "fishermens",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_fishing_trip_history_fishermens_fishermen_id",
                table: "fishing_trip_history");

            migrationBuilder.DropColumn(
                name: "role",
                table: "users");

            migrationBuilder.AddForeignKey(
                name: "fk_fishing_trip_history_fishermens_fishermen_id",
                table: "fishing_trip_history",
                column: "fishermen_id",
                principalTable: "fishermens",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
