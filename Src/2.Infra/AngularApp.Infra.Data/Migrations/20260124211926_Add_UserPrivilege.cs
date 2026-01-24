using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_UserPrivilege : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserPrivileges",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrivilegeId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPrivileges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPrivileges_Privileges_PrivilegeId",
                        column: x => x.PrivilegeId,
                        principalSchema: "Security",
                        principalTable: "Privileges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPrivileges_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPrivileges_PrivilegeId",
                schema: "Security",
                table: "UserPrivileges",
                column: "PrivilegeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPrivileges_UserId",
                schema: "Security",
                table: "UserPrivileges",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPrivileges",
                schema: "Security");
        }
    }
}
