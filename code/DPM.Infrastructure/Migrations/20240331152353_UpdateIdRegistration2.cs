using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DPM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdRegistration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_crew_arrival_registration_arrival_registration_id",
                table: "crew");

            migrationBuilder.DropForeignKey(
                name: "fk_crew_departure_registration_departure_registration_id",
                table: "crew");

            migrationBuilder.DropColumn(
                name: "id",
                table: "departure_registration");

            migrationBuilder.DropColumn(
                name: "id",
                table: "arrival_registration");

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

            migrationBuilder.AddColumn<long>(
                name: "id",
                table: "departure_registration",
                type: "bigint",
                nullable: false,
                defaultValueSql: "generate_id()");

            migrationBuilder.AddColumn<long>(
                name: "id",
                table: "arrival_registration",
                type: "bigint",
                nullable: false,
                defaultValueSql: "generate_id()");

            migrationBuilder.AddForeignKey(
                name: "fk_crew_arrival_registration_arrival_registration_id",
                table: "crew",
                column: "arrival_registration_arrival_id",
                principalTable: "arrival_registration",
                principalColumn: "arrival_id");

            migrationBuilder.AddForeignKey(
                name: "fk_crew_departure_registration_departure_registration_id",
                table: "crew",
                column: "departure_registration_departure_id",
                principalTable: "departure_registration",
                principalColumn: "departure_id");
        }
    }
}
