using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DPM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateConversionEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "country",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "date_of_birth",
                table: "users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "countries",
                table: "crew",
                type: "varchar(128)",
                nullable: false,
                defaultValue: "VN",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldDefaultValue: "242");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "country",
                table: "users");

            migrationBuilder.DropColumn(
                name: "date_of_birth",
                table: "users");

            migrationBuilder.AlterColumn<string>(
                name: "countries",
                table: "crew",
                type: "varchar(128)",
                nullable: false,
                defaultValue: "242",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldDefaultValue: "VN");
        }
    }
}
