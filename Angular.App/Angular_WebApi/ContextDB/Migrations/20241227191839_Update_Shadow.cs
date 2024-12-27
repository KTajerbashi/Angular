using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Angular_WebApi.ContextDB.Migrations
{
    /// <inheritdoc />
    public partial class Update_Shadow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Identity",
                table: "UserTokens",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Identity",
                table: "UserTokens",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<long>(
                name: "CreatedByUserId",
                schema: "Identity",
                table: "UserTokens",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "Identity",
                table: "UserTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 27, 22, 48, 38, 442, DateTimeKind.Local).AddTicks(2892));

            migrationBuilder.AddColumn<long>(
                name: "ModifiedByUserId",
                schema: "Identity",
                table: "UserTokens",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                schema: "Identity",
                table: "UserTokens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Identity",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Identity",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<long>(
                name: "CreatedByUserId",
                schema: "Identity",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "Identity",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 27, 22, 48, 38, 441, DateTimeKind.Local).AddTicks(2551));

            migrationBuilder.AddColumn<long>(
                name: "ModifiedByUserId",
                schema: "Identity",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                schema: "Identity",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Identity",
                table: "UserRoles",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Identity",
                table: "UserRoles",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<long>(
                name: "CreatedByUserId",
                schema: "Identity",
                table: "UserRoles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "Identity",
                table: "UserRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 27, 22, 48, 38, 441, DateTimeKind.Local).AddTicks(9520));

            migrationBuilder.AddColumn<long>(
                name: "ModifiedByUserId",
                schema: "Identity",
                table: "UserRoles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                schema: "Identity",
                table: "UserRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Identity",
                table: "UserLogins",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Identity",
                table: "UserLogins",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<long>(
                name: "CreatedByUserId",
                schema: "Identity",
                table: "UserLogins",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "Identity",
                table: "UserLogins",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 27, 22, 48, 38, 441, DateTimeKind.Local).AddTicks(5686));

            migrationBuilder.AddColumn<long>(
                name: "ModifiedByUserId",
                schema: "Identity",
                table: "UserLogins",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                schema: "Identity",
                table: "UserLogins",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Identity",
                table: "UserClaims",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Identity",
                table: "UserClaims",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<long>(
                name: "CreatedByUserId",
                schema: "Identity",
                table: "UserClaims",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "Identity",
                table: "UserClaims",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 27, 22, 48, 38, 440, DateTimeKind.Local).AddTicks(9282));

            migrationBuilder.AddColumn<long>(
                name: "ModifiedByUserId",
                schema: "Identity",
                table: "UserClaims",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                schema: "Identity",
                table: "UserClaims",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Identity",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Identity",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<long>(
                name: "CreatedByUserId",
                schema: "Identity",
                table: "Roles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "Identity",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 27, 22, 48, 38, 440, DateTimeKind.Local).AddTicks(5990));

            migrationBuilder.AddColumn<long>(
                name: "ModifiedByUserId",
                schema: "Identity",
                table: "Roles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                schema: "Identity",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Identity",
                table: "RoleClaims",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Identity",
                table: "RoleClaims",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<long>(
                name: "CreatedByUserId",
                schema: "Identity",
                table: "RoleClaims",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "Identity",
                table: "RoleClaims",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 27, 22, 48, 38, 440, DateTimeKind.Local).AddTicks(3018));

            migrationBuilder.AddColumn<long>(
                name: "ModifiedByUserId",
                schema: "Identity",
                table: "RoleClaims",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                schema: "Identity",
                table: "RoleClaims",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<long>(
                name: "CreatedByUserId",
                schema: "Product",
                table: "Product",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "Product",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 27, 22, 48, 38, 439, DateTimeKind.Local).AddTicks(9583));

            migrationBuilder.AddColumn<long>(
                name: "ModifiedByUserId",
                schema: "Product",
                table: "Product",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                schema: "Product",
                table: "Product",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                schema: "Identity",
                table: "UserTokens");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                schema: "Identity",
                table: "UserTokens");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                schema: "Identity",
                table: "UserTokens");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                schema: "Identity",
                table: "UserTokens");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                schema: "Identity",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                schema: "Identity",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                schema: "Identity",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                schema: "Identity",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                schema: "Identity",
                table: "UserLogins");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                schema: "Identity",
                table: "UserLogins");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                schema: "Identity",
                table: "UserLogins");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                schema: "Identity",
                table: "UserLogins");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                schema: "Identity",
                table: "UserClaims");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                schema: "Identity",
                table: "UserClaims");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                schema: "Identity",
                table: "UserClaims");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                schema: "Identity",
                table: "UserClaims");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                schema: "Identity",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                schema: "Identity",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                schema: "Identity",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                schema: "Identity",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                schema: "Identity",
                table: "RoleClaims");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                schema: "Identity",
                table: "RoleClaims");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                schema: "Identity",
                table: "RoleClaims");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                schema: "Identity",
                table: "RoleClaims");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                schema: "Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                schema: "Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                schema: "Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                schema: "Product",
                table: "Product");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Identity",
                table: "UserTokens",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Identity",
                table: "UserTokens",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Identity",
                table: "Users",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Identity",
                table: "Users",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Identity",
                table: "UserRoles",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Identity",
                table: "UserRoles",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Identity",
                table: "UserLogins",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Identity",
                table: "UserLogins",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Identity",
                table: "UserClaims",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Identity",
                table: "UserClaims",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Identity",
                table: "Roles",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Identity",
                table: "Roles",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Identity",
                table: "RoleClaims",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Identity",
                table: "RoleClaims",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Product",
                table: "Product",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "Product",
                table: "Product",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);
        }
    }
}
