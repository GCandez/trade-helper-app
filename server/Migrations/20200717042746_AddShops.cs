using Microsoft.EntityFrameworkCore.Migrations;

namespace tradehelperapi.Migrations
{
    public partial class AddShops : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listing_Shop_ShopId",
                table: "Listing");

            migrationBuilder.DropForeignKey(
                name: "FK_Shop_Cities_CityId",
                table: "Shop");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shop",
                table: "Shop");

            migrationBuilder.RenameTable(
                name: "Shop",
                newName: "Shops");

            migrationBuilder.RenameIndex(
                name: "IX_Shop_CityId",
                table: "Shops",
                newName: "IX_Shops_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shops",
                table: "Shops",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Listing_Shops_ShopId",
                table: "Listing",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_Cities_CityId",
                table: "Shops",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listing_Shops_ShopId",
                table: "Listing");

            migrationBuilder.DropForeignKey(
                name: "FK_Shops_Cities_CityId",
                table: "Shops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shops",
                table: "Shops");

            migrationBuilder.RenameTable(
                name: "Shops",
                newName: "Shop");

            migrationBuilder.RenameIndex(
                name: "IX_Shops_CityId",
                table: "Shop",
                newName: "IX_Shop_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shop",
                table: "Shop",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Listing_Shop_ShopId",
                table: "Listing",
                column: "ShopId",
                principalTable: "Shop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shop_Cities_CityId",
                table: "Shop",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
