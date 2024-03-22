using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DPM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_fishermens_id",
                table: "users");

            migrationBuilder.CreateIndex(
                name: "ix_fishermens_user_id",
                table: "fishermens",
                column: "user_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_fishermens_user_user_id",
                table: "fishermens",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_fishermens_user_user_id",
                table: "fishermens");

            migrationBuilder.DropIndex(
                name: "ix_fishermens_user_id",
                table: "fishermens");

            migrationBuilder.AddForeignKey(
                name: "fk_users_fishermens_id",
                table: "users",
                column: "id",
                principalTable: "fishermens",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}