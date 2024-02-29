using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DPM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_certificate_ships_fishing_trips_fishing_trip_id",
                table: "certificate_ships");

            migrationBuilder.DropForeignKey(
                name: "fk_fishermens_fishing_trips_fishing_trip_id",
                table: "fishermens");

            migrationBuilder.DropForeignKey(
                name: "fk_fishing_trip_history_fishermens_fishermen_id",
                table: "fishing_trip_history");

            migrationBuilder.DropForeignKey(
                name: "fk_fishing_trips_fishing_trip_history_id",
                table: "fishing_trips");

            migrationBuilder.DropForeignKey(
                name: "fk_fishing_trips_ship_ship_id",
                table: "fishing_trips");

            migrationBuilder.DropForeignKey(
                name: "fk_fishing_trips_user_creator_id",
                table: "fishing_trips");

            migrationBuilder.DropForeignKey(
                name: "fk_fishing_trips_user_updater_id",
                table: "fishing_trips");

            migrationBuilder.DropIndex(
                name: "ix_fishermens_user_id",
                table: "fishermens");

            migrationBuilder.DropPrimaryKey(
                name: "pk_fishing_trips",
                table: "fishing_trips");

            migrationBuilder.RenameTable(
                name: "fishing_trips",
                newName: "fishing_trip");

            migrationBuilder.RenameIndex(
                name: "ix_fishing_trips_updated_by",
                table: "fishing_trip",
                newName: "ix_fishing_trip_updated_by");

            migrationBuilder.RenameIndex(
                name: "ix_fishing_trips_ship_id",
                table: "fishing_trip",
                newName: "ix_fishing_trip_ship_id");

            migrationBuilder.RenameIndex(
                name: "ix_fishing_trips_created_by",
                table: "fishing_trip",
                newName: "ix_fishing_trip_created_by");

            migrationBuilder.AddPrimaryKey(
                name: "pk_fishing_trip",
                table: "fishing_trip",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_certificate_ships_fishing_trip_fishing_trip_id",
                table: "certificate_ships",
                column: "fishing_trip_id",
                principalTable: "fishing_trip",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_fishermens_fishing_trip_fishing_trip_id",
                table: "fishermens",
                column: "fishing_trip_id",
                principalTable: "fishing_trip",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_fishing_trip_fishing_trip_history_id",
                table: "fishing_trip",
                column: "id",
                principalTable: "fishing_trip_history",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_fishing_trip_ship_ship_id",
                table: "fishing_trip",
                column: "ship_id",
                principalTable: "ships",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_fishing_trip_user_creator_id",
                table: "fishing_trip",
                column: "created_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_fishing_trip_user_updater_id",
                table: "fishing_trip",
                column: "updated_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

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
                name: "fk_certificate_ships_fishing_trip_fishing_trip_id",
                table: "certificate_ships");

            migrationBuilder.DropForeignKey(
                name: "fk_fishermens_fishing_trip_fishing_trip_id",
                table: "fishermens");

            migrationBuilder.DropForeignKey(
                name: "fk_fishing_trip_fishing_trip_history_id",
                table: "fishing_trip");

            migrationBuilder.DropForeignKey(
                name: "fk_fishing_trip_ship_ship_id",
                table: "fishing_trip");

            migrationBuilder.DropForeignKey(
                name: "fk_fishing_trip_user_creator_id",
                table: "fishing_trip");

            migrationBuilder.DropForeignKey(
                name: "fk_fishing_trip_user_updater_id",
                table: "fishing_trip");

            migrationBuilder.DropForeignKey(
                name: "fk_fishing_trip_history_fishermens_fishermen_id",
                table: "fishing_trip_history");

            migrationBuilder.DropPrimaryKey(
                name: "pk_fishing_trip",
                table: "fishing_trip");

            migrationBuilder.RenameTable(
                name: "fishing_trip",
                newName: "fishing_trips");

            migrationBuilder.RenameIndex(
                name: "ix_fishing_trip_updated_by",
                table: "fishing_trips",
                newName: "ix_fishing_trips_updated_by");

            migrationBuilder.RenameIndex(
                name: "ix_fishing_trip_ship_id",
                table: "fishing_trips",
                newName: "ix_fishing_trips_ship_id");

            migrationBuilder.RenameIndex(
                name: "ix_fishing_trip_created_by",
                table: "fishing_trips",
                newName: "ix_fishing_trips_created_by");

            migrationBuilder.AddPrimaryKey(
                name: "pk_fishing_trips",
                table: "fishing_trips",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_fishermens_user_id",
                table: "fishermens",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_certificate_ships_fishing_trips_fishing_trip_id",
                table: "certificate_ships",
                column: "fishing_trip_id",
                principalTable: "fishing_trips",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_fishermens_fishing_trips_fishing_trip_id",
                table: "fishermens",
                column: "fishing_trip_id",
                principalTable: "fishing_trips",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_fishing_trip_history_fishermens_fishermen_id",
                table: "fishing_trip_history",
                column: "fishermen_id",
                principalTable: "fishermens",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_fishing_trips_fishing_trip_history_id",
                table: "fishing_trips",
                column: "id",
                principalTable: "fishing_trip_history",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_fishing_trips_ship_ship_id",
                table: "fishing_trips",
                column: "ship_id",
                principalTable: "ships",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_fishing_trips_user_creator_id",
                table: "fishing_trips",
                column: "created_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_fishing_trips_user_updater_id",
                table: "fishing_trips",
                column: "updated_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
