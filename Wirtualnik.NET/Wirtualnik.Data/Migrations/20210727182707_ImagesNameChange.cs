using Microsoft.EntityFrameworkCore.Migrations;

namespace Wirtualnik.Data.Migrations
{
    public partial class ImagesNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "Images",
                newName: "FileName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Images",
                newName: "FilePath");
        }
    }
}
