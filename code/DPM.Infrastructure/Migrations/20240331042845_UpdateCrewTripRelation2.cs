using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DPM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCrewTripRelation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_crew_arrival_registration_arrival_registration_temp_id1",
                table: "crew");

            migrationBuilder.DropForeignKey(
                name: "fk_crew_departure_registration_departure_registration_temp_id1",
                table: "crew");

            migrationBuilder.DropForeignKey(
                name: "fk_crew_trip_arrival_registration_register_to_arrival_id",
                table: "crew_trip");

            migrationBuilder.DropForeignKey(
                name: "fk_crew_trip_crew_crew_id",
                table: "crew_trip");

            migrationBuilder.DropForeignKey(
                name: "fk_crew_trip_departure_registration_register_to_departure_id",
                table: "crew_trip");

            migrationBuilder.DropIndex(
                name: "ix_crew_trip_trip_id",
                table: "crew_trip");

            migrationBuilder.AddColumn<string>(
                name: "register_to_arrival_arrival_id",
                table: "crew_trip",
                type: "varchar(128)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "register_to_departure_departure_id",
                table: "crew_trip",
                type: "varchar(128)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_crew_trip_register_to_arrival_arrival_id",
                table: "crew_trip",
                column: "register_to_arrival_arrival_id");

            migrationBuilder.CreateIndex(
                name: "ix_crew_trip_register_to_departure_departure_id",
                table: "crew_trip",
                column: "register_to_departure_departure_id");

            migrationBuilder.AddForeignKey(
                name: "fk_crew_arrival_registration_arrival_registration_temp_id",
                table: "crew",
                column: "arrival_registration_arrival_id",
                principalTable: "arrival_registration",
                principalColumn: "arrival_id");

            migrationBuilder.AddForeignKey(
                name: "fk_crew_departure_registration_departure_registration_temp_id",
                table: "crew",
                column: "departure_registration_departure_id",
                principalTable: "departure_registration",
                principalColumn: "departure_id");

            migrationBuilder.AddForeignKey(
                name: "fk_crew_trip_arrival_registration_register_to_arrival_temp_id1",
                table: "crew_trip",
                column: "register_to_arrival_arrival_id",
                principalTable: "arrival_registration",
                principalColumn: "arrival_id");

            migrationBuilder.AddForeignKey(
                name: "fk_crew_trip_crew_crew_id",
                table: "crew_trip",
                column: "crew_id",
                principalTable: "crew",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_crew_trip_departure_registration_register_to_departure_temp",
                table: "crew_trip",
                column: "register_to_departure_departure_id",
                principalTable: "departure_registration",
                principalColumn: "departure_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_crew_arrival_registration_arrival_registration_temp_id",
                table: "crew");

            migrationBuilder.DropForeignKey(
                name: "fk_crew_departure_registration_departure_registration_temp_id",
                table: "crew");

            migrationBuilder.DropForeignKey(
                name: "fk_crew_trip_arrival_registration_register_to_arrival_temp_id1",
                table: "crew_trip");

            migrationBuilder.DropForeignKey(
                name: "fk_crew_trip_crew_crew_id",
                table: "crew_trip");

            migrationBuilder.DropForeignKey(
                name: "fk_crew_trip_departure_registration_register_to_departure_temp",
                table: "crew_trip");

            migrationBuilder.DropIndex(
                name: "ix_crew_trip_register_to_arrival_arrival_id",
                table: "crew_trip");

            migrationBuilder.DropIndex(
                name: "ix_crew_trip_register_to_departure_departure_id",
                table: "crew_trip");

            migrationBuilder.DropColumn(
                name: "register_to_arrival_arrival_id",
                table: "crew_trip");

            migrationBuilder.DropColumn(
                name: "register_to_departure_departure_id",
                table: "crew_trip");

            migrationBuilder.CreateIndex(
                name: "ix_crew_trip_trip_id",
                table: "crew_trip",
                column: "trip_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_crew_arrival_registration_arrival_registration_temp_id1",
                table: "crew",
                column: "arrival_registration_arrival_id",
                principalTable: "arrival_registration",
                principalColumn: "arrival_id");

            migrationBuilder.AddForeignKey(
                name: "fk_crew_departure_registration_departure_registration_temp_id1",
                table: "crew",
                column: "departure_registration_departure_id",
                principalTable: "departure_registration",
                principalColumn: "departure_id");

            migrationBuilder.AddForeignKey(
                name: "fk_crew_trip_arrival_registration_register_to_arrival_id",
                table: "crew_trip",
                column: "trip_id",
                principalTable: "arrival_registration",
                principalColumn: "arrival_id");

            migrationBuilder.AddForeignKey(
                name: "fk_crew_trip_crew_crew_id",
                table: "crew_trip",
                column: "crew_id",
                principalTable: "crew",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_crew_trip_departure_registration_register_to_departure_id",
                table: "crew_trip",
                column: "trip_id",
                principalTable: "departure_registration",
                principalColumn: "departure_id");
        }
    }
}
