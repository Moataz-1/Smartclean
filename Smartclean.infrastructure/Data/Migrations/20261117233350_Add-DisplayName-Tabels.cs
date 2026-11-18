using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smartclean.infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDisplayNameTabels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NachName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "VorName",
                table: "AspNetUsers",
                newName: "DisplayName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisplayName",
                table: "AspNetUsers",
                newName: "VorName");

            migrationBuilder.AddColumn<string>(
                name: "NachName",
                table: "AspNetUsers",
                type: "text",
                nullable: true);
        }
    }
}
