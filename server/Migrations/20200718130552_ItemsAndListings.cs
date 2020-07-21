using Microsoft.EntityFrameworkCore.Migrations;

namespace tradehelperapi.Migrations
{
    public partial class ItemsAndListings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listing_Item_ItemId",
                table: "Listing");

            migrationBuilder.DropForeignKey(
                name: "FK_Listing_Shops_ShopId",
                table: "Listing");

            migrationBuilder.DropForeignKey(
                name: "FK_ListingHistory_Listing_ListingId",
                table: "ListingHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Listing",
                table: "Listing");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.RenameTable(
                name: "Listing",
                newName: "Listings");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");

            migrationBuilder.RenameIndex(
                name: "IX_Listing_ShopId",
                table: "Listings",
                newName: "IX_Listings_ShopId");

            migrationBuilder.RenameIndex(
                name: "IX_Listing_ItemId",
                table: "Listings",
                newName: "IX_Listings_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Listings",
                table: "Listings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ListingHistory_Listings_ListingId",
                table: "ListingHistory",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Items_ItemId",
                table: "Listings",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Shops_ShopId",
                table: "Listings",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListingHistory_Listings_ListingId",
                table: "ListingHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Items_ItemId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Shops_ShopId",
                table: "Listings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Listings",
                table: "Listings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Listings",
                newName: "Listing");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_ShopId",
                table: "Listing",
                newName: "IX_Listing_ShopId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_ItemId",
                table: "Listing",
                newName: "IX_Listing_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Listing",
                table: "Listing",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Listing_Item_ItemId",
                table: "Listing",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listing_Shops_ShopId",
                table: "Listing",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListingHistory_Listing_ListingId",
                table: "ListingHistory",
                column: "ListingId",
                principalTable: "Listing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
