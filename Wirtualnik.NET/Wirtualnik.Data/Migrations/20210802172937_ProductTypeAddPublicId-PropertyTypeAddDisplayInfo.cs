using Microsoft.EntityFrameworkCore.Migrations;

namespace Wirtualnik.Data.Migrations
{
    public partial class ProductTypeAddPublicIdPropertyTypeAddDisplayInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShowInCart",
                table: "PropertyTypes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowInCell",
                table: "PropertyTypes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowInFilter",
                table: "PropertyTypes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "publicId",
                table: "ProductTypes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowInCart",
                table: "PropertyTypes");

            migrationBuilder.DropColumn(
                name: "ShowInCell",
                table: "PropertyTypes");

            migrationBuilder.DropColumn(
                name: "ShowInFilter",
                table: "PropertyTypes");

            migrationBuilder.DropColumn(
                name: "publicId",
                table: "ProductTypes");
        }
    }
}
