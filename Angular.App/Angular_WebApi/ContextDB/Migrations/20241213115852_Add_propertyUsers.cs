using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Angular_WebApi.ContextDB.Migrations
{
    /// <inheritdoc />
    public partial class Add_propertyUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Family",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Family",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Identity",
                table: "Users");
        }
    }
}
