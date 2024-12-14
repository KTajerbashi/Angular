using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Angular_WebApi.ContextDB.Migrations
{
    /// <inheritdoc />
    public partial class Add_Property_Role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "Identity",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                schema: "Identity",
                table: "Roles");
        }
    }
}
