using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DPM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_certificate_ships_fishing_trip_fishing_trip_id",
                table: "certificate_ships");

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
                name: "fk_users_userroles_id",
                table: "users");

            migrationBuilder.DropTable(
                name: "certificate_ship_histories");

            migrationBuilder.DropTable(
                name: "userroles");

            migrationBuilder.DropIndex(
                name: "ix_certificate_ships_fishing_trip_id",
                table: "certificate_ships");

            migrationBuilder.DropColumn(
                name: "fishing_trip_id",
                table: "certificate_ships");

            migrationBuilder.DropColumn(
                name: "is_military_authority",
                table: "certificate_ships");

            migrationBuilder.DropColumn(
                name: "is_port_authority",
                table: "certificate_ships");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "roles",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "generate_id()")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "certificate_no",
                table: "certificate_ships",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "role_name" },
                values: new object[,]
                {
                    { 1L, "Guest" },
                    { 2L, "Guest" }
                });

            migrationBuilder.AddForeignKey(
                name: "fk_fishing_trip_ships_ship_id",
                table: "fishing_trip",
                column: "ship_id",
                principalTable: "ships",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_fishing_trip_users_creator_id",
                table: "fishing_trip",
                column: "created_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_fishing_trip_users_updater_id",
                table: "fishing_trip",
                column: "updated_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_fishing_trip_ships_ship_id",
                table: "fishing_trip");

            migrationBuilder.DropForeignKey(
                name: "fk_fishing_trip_users_creator_id",
                table: "fishing_trip");

            migrationBuilder.DropForeignKey(
                name: "fk_fishing_trip_users_updater_id",
                table: "fishing_trip");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "roles",
                type: "bigint",
                nullable: false,
                defaultValueSql: "generate_id()",
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<Guid>(
                name: "certificate_no",
                table: "certificate_ships",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<long>(
                name: "fishing_trip_id",
                table: "certificate_ships",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "is_military_authority",
                table: "certificate_ships",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_port_authority",
                table: "certificate_ships",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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
                    table.ForeignKey(
                        name: "fk_certificate_ship_histories_certificate_ships_certificate_sh",
                        column: x => x.certificate_ship_id,
                        principalTable: "certificate_ships",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_certificate_ship_histories_user_creator_id",
                        column: x => x.created_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_certificate_ship_histories_user_updater_id",
                        column: x => x.updated_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "userroles",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role = table.Column<int>(type: "integer", nullable: false),
                    role_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_userroles", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_certificate_ships_fishing_trip_id",
                table: "certificate_ships",
                column: "fishing_trip_id");

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

            migrationBuilder.AddForeignKey(
                name: "fk_certificate_ships_fishing_trip_fishing_trip_id",
                table: "certificate_ships",
                column: "fishing_trip_id",
                principalTable: "fishing_trip",
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
                name: "fk_users_userroles_id",
                table: "users",
                column: "id",
                principalTable: "userroles",
                principalColumn: "id");
        }
    }
}