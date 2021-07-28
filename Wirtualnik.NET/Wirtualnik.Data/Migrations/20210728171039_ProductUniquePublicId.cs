using Microsoft.EntityFrameworkCore.Migrations;

namespace Wirtualnik.Data.Migrations
{
    public partial class ProductUniquePublicId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Products_PublicId",
                table: "Products",
                column: "PublicId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_PublicId",
                table: "Products");
        }
    }
}
