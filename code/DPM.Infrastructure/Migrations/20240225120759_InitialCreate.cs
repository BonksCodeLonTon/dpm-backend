using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DPM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "generate_id()"),
                    CognitoSub = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "varchar(64)", nullable: true),
                    Address = table.Column<string>(type: "varchar(256)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(16)", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "varchar(128)", nullable: false),
                    Gender = table.Column<string>(type: "varchar(8)", nullable: true),
                    Avatar = table.Column<string>(type: "varchar(256)", nullable: true),
                    RoleType = table.Column<string>(type: "varchar(16)", nullable: false, defaultValue: "User"),
                    IsDisabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Users_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Fishermens",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "generate_id()"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    YearExperience = table.Column<long>(type: "bigint", nullable: false),
                    VoyageId = table.Column<long>(type: "bigint", nullable: false),
                    IsDisabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fishermens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fishermens_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Fishermens_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Fishermens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "generate_id()"),
                    Name = table.Column<string>(type: "varchar(128)", nullable: false),
                    ClassNumber = table.Column<string>(type: "varchar(128)", nullable: false),
                    IMONumber = table.Column<string>(type: "varchar(128)", nullable: false),
                    RegisterNumber = table.Column<string>(type: "varchar(128)", nullable: false),
                    Purpose = table.Column<string>(type: "text", nullable: false),
                    GrossTonnage = table.Column<string>(type: "varchar(128)", nullable: false),
                    TotalPower = table.Column<string>(type: "varchar(128)", nullable: false),
                    OwnerId = table.Column<long>(type: "bigint", nullable: false),
                    IsDisabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ships_Fishermens_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Fishermens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ships_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Ships_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fishermens_CreatedBy",
                table: "Fishermens",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Fishermens_UpdatedBy",
                table: "Fishermens",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Fishermens_UserId",
                table: "Fishermens",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ships_CreatedBy",
                table: "Ships",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_IMONumber",
                table: "Ships",
                column: "IMONumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ships_OwnerId",
                table: "Ships",
                column: "OwnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ships_UpdatedBy",
                table: "Ships",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedBy",
                table: "Users",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UpdatedBy",
                table: "Users",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ships");

            migrationBuilder.DropTable(
                name: "Fishermens");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
