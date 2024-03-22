using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DPM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_register_to_arrival_users_register_by_user_id",
                table: "register_to_arrival");

            migrationBuilder.DropForeignKey(
                name: "fk_register_to_departure_users_register_by_user_id",
                table: "register_to_departure");

            migrationBuilder.DropIndex(
                name: "ix_register_to_departure_register_by_id",
                table: "register_to_departure");

            migrationBuilder.DropIndex(
                name: "ix_register_to_arrival_register_by_id",
                table: "register_to_arrival");

            migrationBuilder.AddColumn<long[]>(
                name: "array",
                table: "ships",
                type: "bigint[]",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "length",
                table: "ships",
                type: "varchar(128)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<long>(
                name: "created_by",
                table: "register_to_departure",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "attachment",
                table: "register_to_departure",
                type: "varchar(256)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "note",
                table: "register_to_departure",
                type: "varchar(256)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "created_by",
                table: "register_to_arrival",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "attachment",
                table: "register_to_arrival",
                type: "varchar(256)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "note",
                table: "register_to_arrival",
                type: "varchar(256)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "array",
                table: "ships");

            migrationBuilder.DropColumn(
                name: "length",
                table: "ships");

            migrationBuilder.DropColumn(
                name: "attachment",
                table: "register_to_departure");

            migrationBuilder.DropColumn(
                name: "note",
                table: "register_to_departure");

            migrationBuilder.DropColumn(
                name: "attachment",
                table: "register_to_arrival");

            migrationBuilder.DropColumn(
                name: "note",
                table: "register_to_arrival");

            migrationBuilder.AlterColumn<long>(
                name: "created_by",
                table: "register_to_departure",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "created_by",
                table: "register_to_arrival",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "ix_register_to_departure_register_by_id",
                table: "register_to_departure",
                column: "register_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_register_to_arrival_register_by_id",
                table: "register_to_arrival",
                column: "register_by_id");

            migrationBuilder.AddForeignKey(
                name: "fk_register_to_arrival_users_register_by_user_id",
                table: "register_to_arrival",
                column: "register_by_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_register_to_departure_users_register_by_user_id",
                table: "register_to_departure",
                column: "register_by_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
