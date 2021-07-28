using Microsoft.EntityFrameworkCore.Migrations;

namespace Wirtualnik.Data.Migrations
{
    public partial class ImagesColumnChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Images",
                newName: "Width");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "Images",
                newName: "Height");

            migrationBuilder.AddColumn<bool>(
                name: "Main",
                table: "Images",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Main",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "Width",
                table: "Images",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Height",
                table: "Images",
                newName: "Size");
        }
    }
}
