using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DPM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGenerateIdFunc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id",
                table: "register_to_departure");

            migrationBuilder.DropColumn(
                name: "id",
                table: "register_to_arrival");

            migrationBuilder.AlterColumn<string>(
                name: "departure_id",
                table: "register_to_departure",
                type: "varchar(128)",
                nullable: false,
                defaultValueSql: "generate_departure_id()",
                oldClrType: typeof(string),
                oldType: "varchar(128)");

            migrationBuilder.AlterColumn<string>(
                name: "arrival_id",
                table: "register_to_arrival",
                type: "varchar(128)",
                nullable: false,
                defaultValueSql: "generate_arrival_id()",
                oldClrType: typeof(string),
                oldType: "varchar(128)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "departure_id",
                table: "register_to_departure",
                type: "varchar(128)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldDefaultValueSql: "generate_departure_id()");

            migrationBuilder.AddColumn<long>(
                name: "id",
                table: "register_to_departure",
                type: "bigint",
                nullable: false,
                defaultValueSql: "generate_id()");

            migrationBuilder.AlterColumn<string>(
                name: "arrival_id",
                table: "register_to_arrival",
                type: "varchar(128)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldDefaultValueSql: "generate_arrival_id()");

            migrationBuilder.AddColumn<long>(
                name: "id",
                table: "register_to_arrival",
                type: "bigint",
                nullable: false,
                defaultValueSql: "generate_id()");
        }
    }
}
