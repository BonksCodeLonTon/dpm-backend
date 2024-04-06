using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DPM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "country",
                table: "users",
                type: "varchar(32)",
                nullable: false,
                defaultValue: "VN",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "national_id",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "national_id",
                table: "users");

            migrationBuilder.AlterColumn<int>(
                name: "country",
                table: "users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(32)",
                oldDefaultValue: "VN");
        }
    }
}
