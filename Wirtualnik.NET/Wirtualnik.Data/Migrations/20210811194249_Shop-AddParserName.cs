using Microsoft.EntityFrameworkCore.Migrations;

namespace Wirtualnik.Data.Migrations
{
    public partial class ShopAddParserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductShop_Products_ProductId",
                table: "ProductShop");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductShop_Shops_ShopId",
                table: "ProductShop");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductShop",
                table: "ProductShop");

            migrationBuilder.RenameTable(
                name: "ProductShop",
                newName: "ProductShops");

            migrationBuilder.RenameIndex(
                name: "IX_ProductShop_ShopId",
                table: "ProductShops",
                newName: "IX_ProductShops_ShopId");

            migrationBuilder.AddColumn<string>(
                name: "ParserName",
                table: "Shops",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductShops",
                table: "ProductShops",
                columns: new[] { "ProductId", "ShopId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShops_Products_ProductId",
                table: "ProductShops",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShops_Shops_ShopId",
                table: "ProductShops",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductShops_Products_ProductId",
                table: "ProductShops");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductShops_Shops_ShopId",
                table: "ProductShops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductShops",
                table: "ProductShops");

            migrationBuilder.DropColumn(
                name: "ParserName",
                table: "Shops");

            migrationBuilder.RenameTable(
                name: "ProductShops",
                newName: "ProductShop");

            migrationBuilder.RenameIndex(
                name: "IX_ProductShops_ShopId",
                table: "ProductShop",
                newName: "IX_ProductShop_ShopId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductShop",
                table: "ProductShop",
                columns: new[] { "ProductId", "ShopId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShop_Products_ProductId",
                table: "ProductShop",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShop_Shops_ShopId",
                table: "ProductShop",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}