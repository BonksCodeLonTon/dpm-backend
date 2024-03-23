using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DPM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnRoleType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<string>(
                name: "role_type",
                table: "users",
                type: "varchar(16)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(16)",
                oldDefaultValue: "User");

            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "users",
                type: "varchar(16)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(16)",
                oldDefaultValue: "None");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<string>(
                name: "role_type",
                table: "users",
                type: "varchar(16)",
                nullable: false,
                defaultValue: "User",
                oldClrType: typeof(string),
                oldType: "varchar(16)");

            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "users",
                type: "varchar(16)",
                nullable: false,
                defaultValue: "None",
                oldClrType: typeof(string),
                oldType: "varchar(16)");
        }
    }
}
