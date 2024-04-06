using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DPM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "generate_id()"),
                    cognito_sub = table.Column<string>(type: "text", nullable: false),
                    full_name = table.Column<string>(type: "varchar(64)", nullable: true),
                    address = table.Column<string>(type: "varchar(256)", nullable: true),
                    phone_number = table.Column<string>(type: "varchar(16)", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "varchar(128)", nullable: false),
                    gender = table.Column<string>(type: "varchar(8)", nullable: true),
                    avatar = table.Column<string>(type: "varchar(256)", nullable: true),
                    role_type = table.Column<string>(type: "varchar(16)", nullable: false),
                    role = table.Column<string>(type: "varchar(16)", nullable: false),
                    is_disabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    created_by = table.Column<long>(type: "bigint", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_users_creator_id",
                        column: x => x.created_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_users_users_updater_id",
                        column: x => x.updated_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "port",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "generate_id()"),
                    name = table.Column<string>(type: "varchar(128)", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_port", x => x.id);
                    table.ForeignKey(
                        name: "fk_port_users_creator_id",
                        column: x => x.created_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_port_users_updater_id",
                        column: x => x.updated_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ships",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "generate_id()"),
                    name = table.Column<string>(type: "varchar(128)", nullable: false),
                    class_number = table.Column<string>(type: "varchar(128)", nullable: false),
                    imo_number = table.Column<string>(type: "varchar(128)", nullable: false),
                    register_number = table.Column<string>(type: "varchar(128)", nullable: false),
                    gross_tonnage = table.Column<string>(type: "varchar(128)", nullable: false),
                    length = table.Column<string>(type: "varchar(128)", nullable: false),
                    image_path = table.Column<string>(type: "varchar(128)", nullable: true),
                    ship_type = table.Column<string>(type: "varchar(16)", nullable: false, defaultValue: "Other"),
                    ship_status = table.Column<string>(type: "varchar(16)", nullable: false, defaultValue: "Docked"),
                    total_power = table.Column<string>(type: "varchar(128)", nullable: false),
                    owner_id = table.Column<long>(type: "bigint", nullable: true),
                    position = table.Column<double[]>(type: "double precision[]", nullable: true),
                    is_disabled = table.Column<bool>(type: "boolean", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    created_by = table.Column<long>(type: "bigint", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ships", x => x.id);
                    table.ForeignKey(
                        name: "fk_ships_users_creator_id",
                        column: x => x.created_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_ships_users_owner_id",
                        column: x => x.owner_id,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_ships_users_updater_id",
                        column: x => x.updated_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "arrival_registration",
                columns: table => new
                {
                    arrival_id = table.Column<string>(type: "varchar(128)", nullable: false, defaultValueSql: "generate_arrival_id()"),
                    ship_id = table.Column<long>(type: "bigint", nullable: false),
                    port_id = table.Column<long>(type: "bigint", nullable: false),
                    captain_id = table.Column<long>(type: "bigint", nullable: false),
                    approve_status = table.Column<int>(type: "integer", nullable: false),
                    arrival_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    actual_arrival_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    attachment = table.Column<string>(type: "varchar(256)", nullable: true),
                    note = table.Column<string>(type: "varchar(256)", nullable: true),
                    is_start = table.Column<bool>(type: "boolean", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    updated_by = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_arrival_registration", x => x.arrival_id);
                    table.ForeignKey(
                        name: "fk_arrival_registration_port_port_id",
                        column: x => x.port_id,
                        principalTable: "port",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_arrival_registration_ships_ship_id",
                        column: x => x.ship_id,
                        principalTable: "ships",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_arrival_registration_users_captain_id",
                        column: x => x.captain_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_arrival_registration_users_creator_id",
                        column: x => x.created_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_arrival_registration_users_updater_id",
                        column: x => x.updated_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "departure_registration",
                columns: table => new
                {
                    departure_id = table.Column<string>(type: "varchar(128)", nullable: false, defaultValueSql: "generate_departure_id()"),
                    ship_id = table.Column<long>(type: "bigint", nullable: false),
                    port_id = table.Column<long>(type: "bigint", nullable: false),
                    attachment = table.Column<string>(type: "varchar(256)", nullable: true),
                    captain_id = table.Column<long>(type: "bigint", nullable: false),
                    crew_id = table.Column<long[]>(type: "bigint[]", nullable: true),
                    departure_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    actual_departure_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    guess_time_arrival = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    approve_status = table.Column<int>(type: "integer", nullable: false),
                    note = table.Column<string>(type: "varchar(256)", nullable: true),
                    is_start = table.Column<bool>(type: "boolean", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    updated_by = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_departure_registration", x => x.departure_id);
                    table.ForeignKey(
                        name: "fk_departure_registration_port_port_id",
                        column: x => x.port_id,
                        principalTable: "port",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_departure_registration_ships_ship_id",
                        column: x => x.ship_id,
                        principalTable: "ships",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_departure_registration_users_captain_id",
                        column: x => x.captain_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_departure_registration_users_creator_id",
                        column: x => x.created_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_departure_registration_users_updater_id",
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
                name: "crew",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "generate_id()"),
                    fullname = table.Column<string>(type: "varchar(128)", nullable: false),
                    countries = table.Column<string>(type: "text", nullable: false),
                    national_id = table.Column<string>(type: "text", nullable: false),
                    year_experience = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    relative_phone_number = table.Column<string>(type: "text", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: true),
                    arrival_registration_arrival_id = table.Column<string>(type: "varchar(128)", nullable: true),
                    departure_registration_departure_id = table.Column<string>(type: "varchar(128)", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_crew", x => x.id);
                    table.ForeignKey(
                        name: "fk_crew_arrival_registration_arrival_registration_temp_id1",
                        column: x => x.arrival_registration_arrival_id,
                        principalTable: "arrival_registration",
                        principalColumn: "arrival_id");
                    table.ForeignKey(
                        name: "fk_crew_departure_registration_departure_registration_temp_id1",
                        column: x => x.departure_registration_departure_id,
                        principalTable: "departure_registration",
                        principalColumn: "departure_id");
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
                name: "crew_trip",
                columns: table => new
                {
                    trip_id = table.Column<string>(type: "varchar(128)", nullable: true),
                    crew_id = table.Column<long>(type: "bigint", nullable: false),
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "fk_crew_trip_arrival_registration_register_to_arrival_id",
                        column: x => x.trip_id,
                        principalTable: "arrival_registration",
                        principalColumn: "arrival_id");
                    table.ForeignKey(
                        name: "fk_crew_trip_crew_crew_id",
                        column: x => x.crew_id,
                        principalTable: "crew",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_crew_trip_departure_registration_register_to_departure_id",
                        column: x => x.trip_id,
                        principalTable: "departure_registration",
                        principalColumn: "departure_id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_arrival_registration_captain_id",
                table: "arrival_registration",
                column: "captain_id");

            migrationBuilder.CreateIndex(
                name: "ix_arrival_registration_created_by",
                table: "arrival_registration",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_arrival_registration_port_id",
                table: "arrival_registration",
                column: "port_id");

            migrationBuilder.CreateIndex(
                name: "ix_arrival_registration_ship_id",
                table: "arrival_registration",
                column: "ship_id");

            migrationBuilder.CreateIndex(
                name: "ix_arrival_registration_updated_by",
                table: "arrival_registration",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "ix_crew_arrival_registration_arrival_id",
                table: "crew",
                column: "arrival_registration_arrival_id");

            migrationBuilder.CreateIndex(
                name: "ix_crew_created_by",
                table: "crew",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_crew_departure_registration_departure_id",
                table: "crew",
                column: "departure_registration_departure_id");

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
                name: "ix_departure_registration_captain_id",
                table: "departure_registration",
                column: "captain_id");

            migrationBuilder.CreateIndex(
                name: "ix_departure_registration_created_by",
                table: "departure_registration",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_departure_registration_port_id",
                table: "departure_registration",
                column: "port_id");

            migrationBuilder.CreateIndex(
                name: "ix_departure_registration_ship_id",
                table: "departure_registration",
                column: "ship_id");

            migrationBuilder.CreateIndex(
                name: "ix_departure_registration_updated_by",
                table: "departure_registration",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "ix_port_created_by",
                table: "port",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_port_updated_by",
                table: "port",
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

            migrationBuilder.CreateIndex(
                name: "ix_ships_created_by",
                table: "ships",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_ships_imo_number",
                table: "ships",
                column: "imo_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_ships_owner_id",
                table: "ships",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "ix_ships_updated_by",
                table: "ships",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "ix_users_cognito_sub",
                table: "users",
                column: "cognito_sub",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_created_by",
                table: "users",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_updated_by",
                table: "users",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "ix_users_username",
                table: "users",
                column: "username",
                unique: true);
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
                name: "arrival_registration");

            migrationBuilder.DropTable(
                name: "departure_registration");

            migrationBuilder.DropTable(
                name: "port");

            migrationBuilder.DropTable(
                name: "ships");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
