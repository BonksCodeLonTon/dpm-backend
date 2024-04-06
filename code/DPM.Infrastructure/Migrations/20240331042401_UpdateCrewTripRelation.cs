using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DPM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCrewTripRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_crew_trip_crew_crew_id",
                table: "crew_trip");

            migrationBuilder.AddForeignKey(
                name: "fk_crew_trip_crew_crew_id",
                table: "crew_trip",
                column: "crew_id",
                principalTable: "crew",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_crew_trip_crew_crew_id",
                table: "crew_trip");

            migrationBuilder.AddForeignKey(
                name: "fk_crew_trip_crew_crew_id",
                table: "crew_trip",
                column: "crew_id",
                principalTable: "crew",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
