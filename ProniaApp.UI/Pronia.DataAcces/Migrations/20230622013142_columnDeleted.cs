using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pronia.DataAcces.Migrations
{
    public partial class columnDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Sliders",
                newName: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Sliders",
                newName: "Name");
        }
    }
}
