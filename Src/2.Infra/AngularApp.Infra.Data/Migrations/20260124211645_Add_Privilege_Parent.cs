using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Privilege_Parent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Privileges_Privileges_PrivilegeEntityId",
                schema: "Security",
                table: "Privileges");

            migrationBuilder.DropIndex(
                name: "IX_Privileges_PrivilegeEntityId",
                schema: "Security",
                table: "Privileges");

            migrationBuilder.DropColumn(
                name: "PrivilegeEntityId",
                schema: "Security",
                table: "Privileges");

            migrationBuilder.CreateIndex(
                name: "IX_Privileges_ParentId",
                schema: "Security",
                table: "Privileges",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Privileges_Privileges_ParentId",
                schema: "Security",
                table: "Privileges",
                column: "ParentId",
                principalSchema: "Security",
                principalTable: "Privileges",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Privileges_Privileges_ParentId",
                schema: "Security",
                table: "Privileges");

            migrationBuilder.DropIndex(
                name: "IX_Privileges_ParentId",
                schema: "Security",
                table: "Privileges");

            migrationBuilder.AddColumn<long>(
                name: "PrivilegeEntityId",
                schema: "Security",
                table: "Privileges",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Privileges_PrivilegeEntityId",
                schema: "Security",
                table: "Privileges",
                column: "PrivilegeEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Privileges_Privileges_PrivilegeEntityId",
                schema: "Security",
                table: "Privileges",
                column: "PrivilegeEntityId",
                principalSchema: "Security",
                principalTable: "Privileges",
                principalColumn: "Id");
        }
    }
}
