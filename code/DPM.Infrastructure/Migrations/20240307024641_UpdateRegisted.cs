using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DPM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRegisted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_fishermens_fishing_trip_fishing_trip_id",
                table: "fishermens");

            migrationBuilder.DropTable(
                name: "certificate_ships");

            migrationBuilder.DropTable(
                name: "map");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "fishing_trip");

            migrationBuilder.DropTable(
                name: "fishing_trip_history");

            migrationBuilder.DropTable(
                name: "fishermens");

            migrationBuilder.DropColumn(
                name: "purpose",
                table: "ships");

            migrationBuilder.AddColumn<string>(
                name: "ship_status",
                table: "ships",
                type: "varchar(16)",
                nullable: false,
                defaultValue: "Docked");

            migrationBuilder.AddColumn<string>(
                name: "ship_type",
                table: "ships",
                type: "varchar(16)",
                nullable: false,
                defaultValue: "Other");

            migrationBuilder.CreateTable(
                name: "crew",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "generate_id()"),
                    fullname = table.Column<string>(type: "text", nullable: true),
                    countries = table.Column<string>(type: "text", nullable: false),
                    national_id = table.Column<string>(type: "text", nullable: true),
                    year_experience = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_crew", x => x.id);
                    table.ForeignKey(
                        name: "fk_crew_users_creator_id",
                        column: x => x.created_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_crew_users_updater_id",
                        column: x => x.updated_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "register_to_arrival",
                columns: table => new
                {
                    arrival_id = table.Column<string>(type: "varchar(128)", nullable: false),
                    register_by_id = table.Column<long>(type: "bigint", nullable: false),
                    ship_id = table.Column<long>(type: "bigint", nullable: false),
                    port_id = table.Column<long>(type: "bigint", nullable: false),
                    captain_id = table.Column<long>(type: "bigint", nullable: false),
                    approve_status = table.Column<int>(type: "integer", nullable: false),
                    arrival_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    actual_arrival_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_start = table.Column<bool>(type: "boolean", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: true),
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "generate_id()"),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_register_to_arrival", x => x.arrival_id);
                    table.ForeignKey(
                        name: "fk_register_to_arrival_ships_ship_id",
                        column: x => x.ship_id,
                        principalTable: "ships",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_register_to_arrival_users_captain_id",
                        column: x => x.captain_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_register_to_arrival_users_creator_id",
                        column: x => x.created_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_register_to_arrival_users_register_by_user_id",
                        column: x => x.register_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_register_to_arrival_users_updater_id",
                        column: x => x.updated_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "register_to_departure",
                columns: table => new
                {
                    departure_id = table.Column<string>(type: "varchar(128)", nullable: false),
                    register_by_id = table.Column<long>(type: "bigint", nullable: false),
                    ship_id = table.Column<long>(type: "bigint", nullable: false),
                    port_id = table.Column<long>(type: "bigint", nullable: false),
                    captain_id = table.Column<long>(type: "bigint", nullable: false),
                    departure_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    actual_departure_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    guess_time_arrival = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    approve_status = table.Column<int>(type: "integer", nullable: false),
                    is_start = table.Column<bool>(type: "boolean", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: true),
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "generate_id()"),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_register_to_departure", x => x.departure_id);
                    table.ForeignKey(
                        name: "fk_register_to_departure_ships_ship_id",
                        column: x => x.ship_id,
                        principalTable: "ships",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_register_to_departure_users_captain_id",
                        column: x => x.captain_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_register_to_departure_users_creator_id",
                        column: x => x.created_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_register_to_departure_users_register_by_user_id",
                        column: x => x.register_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_register_to_departure_users_updater_id",
                        column: x => x.updated_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ship_certificate",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "generate_id()"),
                    certificate_name = table.Column<string>(type: "varchar(128)", nullable: false),
                    certificate_no = table.Column<string>(type: "text", nullable: false),
                    certificate_status = table.Column<string>(type: "varchar(64)", nullable: false, defaultValue: "None"),
                    issue_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    expiry_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ship_id = table.Column<long>(type: "bigint", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: true),
                    creator_id = table.Column<long>(type: "bigint", nullable: true),
                    updater_id = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ship_certificate", x => x.id);
                    table.ForeignKey(
                        name: "fk_ship_certificate_ships_ship_id",
                        column: x => x.ship_id,
                        principalTable: "ships",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_ship_certificate_users_creator_id",
                        column: x => x.creator_id,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_ship_certificate_users_updater_id",
                        column: x => x.updater_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "crew_trip",
                columns: table => new
                {
                    trip_id = table.Column<string>(type: "varchar(128)", nullable: true),
                    crew_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "fk_crew_trip_crew_crew_id",
                        column: x => x.crew_id,
                        principalTable: "crew",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_crew_trip_register_to_arrival_register_to_arrival_id",
                        column: x => x.trip_id,
                        principalTable: "register_to_arrival",
                        principalColumn: "arrival_id");
                    table.ForeignKey(
                        name: "fk_crew_trip_register_to_departure_register_to_departure_id",
                        column: x => x.trip_id,
                        principalTable: "register_to_departure",
                        principalColumn: "departure_id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_crew_created_by",
                table: "crew",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_crew_updated_by",
                table: "crew",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "ix_crew_trip_crew_id",
                table: "crew_trip",
                column: "crew_id");

            migrationBuilder.CreateIndex(
                name: "ix_crew_trip_trip_id",
                table: "crew_trip",
                column: "trip_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_register_to_arrival_captain_id",
                table: "register_to_arrival",
                column: "captain_id");

            migrationBuilder.CreateIndex(
                name: "ix_register_to_arrival_created_by",
                table: "register_to_arrival",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_register_to_arrival_register_by_id",
                table: "register_to_arrival",
                column: "register_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_register_to_arrival_ship_id",
                table: "register_to_arrival",
                column: "ship_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_register_to_arrival_updated_by",
                table: "register_to_arrival",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "ix_register_to_departure_captain_id",
                table: "register_to_departure",
                column: "captain_id");

            migrationBuilder.CreateIndex(
                name: "ix_register_to_departure_created_by",
                table: "register_to_departure",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_register_to_departure_register_by_id",
                table: "register_to_departure",
                column: "register_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_register_to_departure_ship_id",
                table: "register_to_departure",
                column: "ship_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_register_to_departure_updated_by",
                table: "register_to_departure",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "ix_ship_certificate_certificate_name",
                table: "ship_certificate",
                column: "certificate_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_ship_certificate_certificate_no",
                table: "ship_certificate",
                column: "certificate_no",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_ship_certificate_creator_id",
                table: "ship_certificate",
                column: "creator_id");

            migrationBuilder.CreateIndex(
                name: "ix_ship_certificate_ship_id",
                table: "ship_certificate",
                column: "ship_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_ship_certificate_updater_id",
                table: "ship_certificate",
                column: "updater_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "crew_trip");

            migrationBuilder.DropTable(
                name: "ship_certificate");

            migrationBuilder.DropTable(
                name: "crew");

            migrationBuilder.DropTable(
                name: "register_to_arrival");

            migrationBuilder.DropTable(
                name: "register_to_departure");

            migrationBuilder.DropColumn(
                name: "ship_status",
                table: "ships");

            migrationBuilder.DropColumn(
                name: "ship_type",
                table: "ships");

            migrationBuilder.AddColumn<string>(
                name: "purpose",
                table: "ships",
                type: "varchar(16)",
                nullable: false,
                defaultValue: "None");

            migrationBuilder.CreateTable(
                name: "certificate_ships",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "generate_id()"),
                    certificate_name = table.Column<string>(type: "text", nullable: true),
                    certificate_no = table.Column<string>(type: "text", nullable: false),
                    certificate_status = table.Column<string>(type: "varchar(64)", nullable: false, defaultValue: "None"),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    expiry_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    issue_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_certificate_ships", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "map",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "generate_id()"),
                    ship_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    position = table.Column<List<long>>(type: "bigint[]", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_map", x => x.id);
                    table.ForeignKey(
                        name: "fk_map_ships_ship_id",
                        column: x => x.ship_id,
                        principalTable: "ships",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_name = table.Column<string>(type: "varchar(16)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "fishermens",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "generate_id()"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    fishing_trip_id = table.Column<long>(type: "bigint", nullable: true),
                    year_experience = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fishermens", x => x.id);
                    table.ForeignKey(
                        name: "fk_fishermens_user_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "fishing_trip_history",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "generate_id()"),
                    fishermen_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fishing_trip_id = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fishing_trip_history", x => x.id);
                    table.ForeignKey(
                        name: "fk_fishing_trip_history_fishermens_fishermen_id",
                        column: x => x.fishermen_id,
                        principalTable: "fishermens",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "fishing_trip",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: true),
                    ship_id = table.Column<long>(type: "bigint", nullable: false),
                    updated_by = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    ship_status = table.Column<string>(type: "varchar(16)", nullable: false, defaultValue: "Idle"),
                    trip_status = table.Column<string>(type: "varchar(16)", nullable: false, defaultValue: "Undefined"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fishing_trip", x => x.id);
                    table.ForeignKey(
                        name: "fk_fishing_trip_fishing_trip_history_id",
                        column: x => x.id,
                        principalTable: "fishing_trip_history",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_fishing_trip_ships_ship_id",
                        column: x => x.ship_id,
                        principalTable: "ships",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_fishing_trip_users_creator_id",
                        column: x => x.created_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_fishing_trip_users_updater_id",
                        column: x => x.updated_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "role_name" },
                values: new object[,]
                {
                    { 1L, "Guest" },
                    { 2L, "Guest" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_fishermens_fishing_trip_id",
                table: "fishermens",
                column: "fishing_trip_id");

            migrationBuilder.CreateIndex(
                name: "ix_fishermens_user_id",
                table: "fishermens",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_fishing_trip_created_by",
                table: "fishing_trip",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_fishing_trip_ship_id",
                table: "fishing_trip",
                column: "ship_id");

            migrationBuilder.CreateIndex(
                name: "ix_fishing_trip_updated_by",
                table: "fishing_trip",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "ix_fishing_trip_history_fishermen_id",
                table: "fishing_trip_history",
                column: "fishermen_id");

            migrationBuilder.CreateIndex(
                name: "ix_fishing_trip_history_fishing_trip_id",
                table: "fishing_trip_history",
                column: "fishing_trip_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_map_ship_id",
                table: "map",
                column: "ship_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_fishermens_fishing_trip_fishing_trip_id",
                table: "fishermens",
                column: "fishing_trip_id",
                principalTable: "fishing_trip",
                principalColumn: "id");
        }
    }
}
