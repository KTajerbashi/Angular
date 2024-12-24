using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Angular_WebApi.ContextDB.Migrations
{
    /// <inheritdoc />
    public partial class Add_Online_Property : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOnline",
                schema: "Identity",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOnline",
                schema: "Identity",
                table: "Users");
        }
    }
}
