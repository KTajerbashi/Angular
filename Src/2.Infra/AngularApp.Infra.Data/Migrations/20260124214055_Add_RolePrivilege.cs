using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_RolePrivilege : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RolePrivileges",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrivilegeId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_RolePrivileges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePrivileges_Privileges_PrivilegeId",
                        column: x => x.PrivilegeId,
                        principalSchema: "Security",
                        principalTable: "Privileges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePrivileges_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Security",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolePrivileges_PrivilegeId",
                schema: "Security",
                table: "RolePrivileges",
                column: "PrivilegeId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePrivileges_RoleId",
                schema: "Security",
                table: "RolePrivileges",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePrivileges",
                schema: "Security");
        }
    }
}
