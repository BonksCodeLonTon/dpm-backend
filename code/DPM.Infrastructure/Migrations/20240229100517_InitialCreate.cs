using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DPM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "generate_id()"),
                    role_name = table.Column<string>(type: "varchar(16)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "userroles",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    role_id = table.Column<long>(type: "bigint", nullable: false),
                    role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_userroles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "certificate_ship_histories",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    certificate_ship_id = table.Column<long>(type: "bigint", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_certificate_ship_histories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "certificate_ships",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "generate_id()"),
                    certificate_name = table.Column<string>(type: "text", nullable: true),
                    certificate_no = table.Column<Guid>(type: "uuid", nullable: false),
                    certificate_status = table.Column<string>(type: "varchar(64)", nullable: false, defaultValue: "None"),
                    is_military_authority = table.Column<bool>(type: "boolean", nullable: false),
                    is_port_authority = table.Column<bool>(type: "boolean", nullable: false),
                    issue_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    expiry_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fishing_trip_id = table.Column<long>(type: "bigint", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_certificate_ships", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "fishermens",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "generate_id()"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    year_experience = table.Column<long>(type: "bigint", nullable: false),
                    fishing_trip_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fishermens", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "fishing_trip_history",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "generate_id()"),
                    fishing_trip_id = table.Column<long>(type: "bigint", nullable: false),
                    fishermen_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fishing_trip_history", x => x.id);
                    table.ForeignKey(
                        name: "fk_fishing_trip_history_fishermens_fishermen_id",
                        column: x => x.fishermen_id,
                        principalTable: "fishermens",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    role_type = table.Column<string>(type: "varchar(16)", nullable: false, defaultValue: "User"),
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
                        name: "fk_users_fishermens_id",
                        column: x => x.id,
                        principalTable: "fishermens",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_users_userroles_id",
                        column: x => x.id,
                        principalTable: "userroles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "ships",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "generate_id()"),
                    name = table.Column<string>(type: "varchar(128)", nullable: false),
                    class_number = table.Column<string>(type: "varchar(128)", nullable: false),
                    imo_number = table.Column<string>(type: "varchar(128)", nullable: false),
                    register_number = table.Column<string>(type: "varchar(128)", nullable: false),
                    gross_tonnage = table.Column<string>(type: "varchar(128)", nullable: false),
                    purpose = table.Column<string>(type: "varchar(16)", nullable: false, defaultValue: "None"),
                    total_power = table.Column<string>(type: "varchar(128)", nullable: false),
                    owner_id = table.Column<long>(type: "bigint", nullable: true),
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
                name: "fishing_trips",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    ship_id = table.Column<long>(type: "bigint", nullable: false),
                    trip_status = table.Column<string>(type: "varchar(16)", nullable: false, defaultValue: "Undefined"),
                    ship_status = table.Column<string>(type: "varchar(16)", nullable: false, defaultValue: "Idle"),
                    created_by = table.Column<long>(type: "bigint", nullable: true),
                    updated_by = table.Column<long>(type: "bigint", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fishing_trips", x => x.id);
                    table.ForeignKey(
                        name: "fk_fishing_trips_fishing_trip_history_id",
                        column: x => x.id,
                        principalTable: "fishing_trip_history",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_fishing_trips_ship_ship_id",
                        column: x => x.ship_id,
                        principalTable: "ships",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_fishing_trips_user_creator_id",
                        column: x => x.created_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_fishing_trips_user_updater_id",
                        column: x => x.updated_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "map",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "generate_id()"),
                    ship_id = table.Column<long>(type: "bigint", nullable: false),
                    position = table.Column<List<long>>(type: "bigint[]", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "ix_certificate_ship_histories_certificate_ship_id",
                table: "certificate_ship_histories",
                column: "certificate_ship_id");

            migrationBuilder.CreateIndex(
                name: "ix_certificate_ship_histories_created_by",
                table: "certificate_ship_histories",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_certificate_ship_histories_updated_by",
                table: "certificate_ship_histories",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "ix_certificate_ships_fishing_trip_id",
                table: "certificate_ships",
                column: "fishing_trip_id");

            migrationBuilder.CreateIndex(
                name: "ix_fishermens_fishing_trip_id",
                table: "fishermens",
                column: "fishing_trip_id");

            migrationBuilder.CreateIndex(
                name: "ix_fishermens_user_id",
                table: "fishermens",
                column: "user_id");

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
                name: "ix_fishing_trips_created_by",
                table: "fishing_trips",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_fishing_trips_ship_id",
                table: "fishing_trips",
                column: "ship_id");

            migrationBuilder.CreateIndex(
                name: "ix_fishing_trips_updated_by",
                table: "fishing_trips",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "ix_map_ship_id",
                table: "map",
                column: "ship_id",
                unique: true);

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
                column: "owner_id",
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "fk_certificate_ship_histories_certificate_ships_certificate_sh",
                table: "certificate_ship_histories",
                column: "certificate_ship_id",
                principalTable: "certificate_ships",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_certificate_ship_histories_user_creator_id",
                table: "certificate_ship_histories",
                column: "created_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_certificate_ship_histories_user_updater_id",
                table: "certificate_ship_histories",
                column: "updated_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_fishing_trips_user_creator_id",
                table: "fishing_trips");

            migrationBuilder.DropForeignKey(
                name: "fk_fishing_trips_user_updater_id",
                table: "fishing_trips");

            migrationBuilder.DropForeignKey(
                name: "fk_ships_users_creator_id",
                table: "ships");

            migrationBuilder.DropForeignKey(
                name: "fk_ships_users_owner_id",
                table: "ships");

            migrationBuilder.DropForeignKey(
                name: "fk_ships_users_updater_id",
                table: "ships");

            migrationBuilder.DropForeignKey(
                name: "fk_fishermens_fishing_trips_fishing_trip_id",
                table: "fishermens");

            migrationBuilder.DropTable(
                name: "certificate_ship_histories");

            migrationBuilder.DropTable(
                name: "map");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "certificate_ships");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "userroles");

            migrationBuilder.DropTable(
                name: "fishing_trips");

            migrationBuilder.DropTable(
                name: "fishing_trip_history");

            migrationBuilder.DropTable(
                name: "ships");

            migrationBuilder.DropTable(
                name: "fishermens");
        }
    }
}