using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smartclean.infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNameTabels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisplayName",
                table: "AspNetUsers",
                newName: "Vorname");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Vorname",
                table: "AspNetUsers",
                newName: "DisplayName");
        }
    }
}
