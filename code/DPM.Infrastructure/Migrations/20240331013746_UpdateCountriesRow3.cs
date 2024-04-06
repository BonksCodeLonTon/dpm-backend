using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DPM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCountriesRow3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "countries",
                table: "crew",
                type: "varchar(128)",
                nullable: false,
                defaultValue: "242",
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "countries",
                table: "crew",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldDefaultValue: "242");
        }
    }
}
