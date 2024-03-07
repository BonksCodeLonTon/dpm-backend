using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DPM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPortEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_register_to_departure_ship_id",
                table: "register_to_departure");

            migrationBuilder.DropIndex(
                name: "ix_register_to_arrival_ship_id",
                table: "register_to_arrival");

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

            migrationBuilder.CreateIndex(
                name: "ix_register_to_departure_port_id",
                table: "register_to_departure",
                column: "port_id");

            migrationBuilder.CreateIndex(
                name: "ix_register_to_departure_ship_id",
                table: "register_to_departure",
                column: "ship_id");

            migrationBuilder.CreateIndex(
                name: "ix_register_to_arrival_port_id",
                table: "register_to_arrival",
                column: "port_id");

            migrationBuilder.CreateIndex(
                name: "ix_register_to_arrival_ship_id",
                table: "register_to_arrival",
                column: "ship_id");

            migrationBuilder.CreateIndex(
                name: "ix_port_created_by",
                table: "port",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_port_updated_by",
                table: "port",
                column: "updated_by");

            migrationBuilder.AddForeignKey(
                name: "fk_register_to_arrival_port_port_id",
                table: "register_to_arrival",
                column: "port_id",
                principalTable: "port",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_register_to_departure_port_port_id",
                table: "register_to_departure",
                column: "port_id",
                principalTable: "port",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_register_to_arrival_port_port_id",
                table: "register_to_arrival");

            migrationBuilder.DropForeignKey(
                name: "fk_register_to_departure_port_port_id",
                table: "register_to_departure");

            migrationBuilder.DropTable(
                name: "port");

            migrationBuilder.DropIndex(
                name: "ix_register_to_departure_port_id",
                table: "register_to_departure");

            migrationBuilder.DropIndex(
                name: "ix_register_to_departure_ship_id",
                table: "register_to_departure");

            migrationBuilder.DropIndex(
                name: "ix_register_to_arrival_port_id",
                table: "register_to_arrival");

            migrationBuilder.DropIndex(
                name: "ix_register_to_arrival_ship_id",
                table: "register_to_arrival");

            migrationBuilder.CreateIndex(
                name: "ix_register_to_departure_ship_id",
                table: "register_to_departure",
                column: "ship_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_register_to_arrival_ship_id",
                table: "register_to_arrival",
                column: "ship_id",
                unique: true);
        }
    }
}
