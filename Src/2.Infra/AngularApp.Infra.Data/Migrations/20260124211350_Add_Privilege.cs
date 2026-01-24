using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Privilege : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Privileges",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    EntityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    Command = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    PrivilegeEntityId = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privileges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Privileges_Privileges_PrivilegeEntityId",
                        column: x => x.PrivilegeEntityId,
                        principalSchema: "Security",
                        principalTable: "Privileges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Privileges_PrivilegeEntityId",
                schema: "Security",
                table: "Privileges",
                column: "PrivilegeEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Privileges",
                schema: "Security");
        }
    }
}
