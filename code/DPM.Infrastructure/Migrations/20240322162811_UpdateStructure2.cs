using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DPM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStructure2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "register_by_id",
                table: "register_to_departure");

            migrationBuilder.DropColumn(
                name: "register_by_id",
                table: "register_to_arrival");

            migrationBuilder.AddColumn<long[]>(
                name: "crew_id",
                table: "register_to_departure",
                type: "bigint[]",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "crew_trip",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "id",
                table: "crew_trip",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "crew_trip",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "register_to_arrival_arrival_id",
                table: "crew",
                type: "varchar(128)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "register_to_departure_departure_id",
                table: "crew",
                type: "varchar(128)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_crew_register_to_arrival_arrival_id",
                table: "crew",
                column: "register_to_arrival_arrival_id");

            migrationBuilder.CreateIndex(
                name: "ix_crew_register_to_departure_departure_id",
                table: "crew",
                column: "register_to_departure_departure_id");

            migrationBuilder.AddForeignKey(
                name: "fk_crew_register_to_arrival_register_to_arrival_temp_id1",
                table: "crew",
                column: "register_to_arrival_arrival_id",
                principalTable: "register_to_arrival",
                principalColumn: "arrival_id");

            migrationBuilder.AddForeignKey(
                name: "fk_crew_register_to_departure_register_to_departure_temp_id1",
                table: "crew",
                column: "register_to_departure_departure_id",
                principalTable: "register_to_departure",
                principalColumn: "departure_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_crew_register_to_arrival_register_to_arrival_temp_id1",
                table: "crew");

            migrationBuilder.DropForeignKey(
                name: "fk_crew_register_to_departure_register_to_departure_temp_id1",
                table: "crew");

            migrationBuilder.DropIndex(
                name: "ix_crew_register_to_arrival_arrival_id",
                table: "crew");

            migrationBuilder.DropIndex(
                name: "ix_crew_register_to_departure_departure_id",
                table: "crew");

            migrationBuilder.DropColumn(
                name: "crew_id",
                table: "register_to_departure");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "crew_trip");

            migrationBuilder.DropColumn(
                name: "id",
                table: "crew_trip");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "crew_trip");

            migrationBuilder.DropColumn(
                name: "register_to_arrival_arrival_id",
                table: "crew");

            migrationBuilder.DropColumn(
                name: "register_to_departure_departure_id",
                table: "crew");

            migrationBuilder.AddColumn<long>(
                name: "register_by_id",
                table: "register_to_departure",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "register_by_id",
                table: "register_to_arrival",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
