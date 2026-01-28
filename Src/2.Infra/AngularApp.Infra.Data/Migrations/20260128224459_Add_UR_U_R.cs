using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_UR_U_R : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                schema: "Security",
                table: "UserRoles");

            migrationBuilder.AddColumn<bool>(
                name: "IsOnline",
                schema: "Security",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Security",
                table: "UserRoles",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                schema: "Security",
                table: "UserRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                schema: "Security",
                table: "UserRoles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                schema: "Security",
                table: "UserRoles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                schema: "Security",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_UserId",
                schema: "Security",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "IsOnline",
                schema: "Security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Security",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                schema: "Security",
                table: "UserRoles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                schema: "Security",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" });
        }
    }
}
