using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DPM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForeignOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_ships_owner_id",
                table: "ships");

            migrationBuilder.CreateIndex(
                name: "ix_ships_owner_id",
                table: "ships",
                column: "owner_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_ships_owner_id",
                table: "ships");

            migrationBuilder.CreateIndex(
                name: "ix_ships_owner_id",
                table: "ships",
                column: "owner_id",
                unique: true);
        }
    }
}
