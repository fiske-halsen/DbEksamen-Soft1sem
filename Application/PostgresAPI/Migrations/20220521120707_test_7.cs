using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostgresAPI.Migrations
{
    public partial class test_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_MenuItemType_MenuItemTypeId",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_RestaurantType_ResturantTypeId",
                table: "Restaurants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantType",
                table: "RestaurantType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItemType",
                table: "MenuItemType");

            migrationBuilder.RenameTable(
                name: "RestaurantType",
                newName: "RestaurantTypes");

            migrationBuilder.RenameTable(
                name: "MenuItemType",
                newName: "MenuItemTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantTypes",
                table: "RestaurantTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItemTypes",
                table: "MenuItemTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_MenuItemTypes_MenuItemTypeId",
                table: "MenuItems",
                column: "MenuItemTypeId",
                principalTable: "MenuItemTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_RestaurantTypes_ResturantTypeId",
                table: "Restaurants",
                column: "ResturantTypeId",
                principalTable: "RestaurantTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_MenuItemTypes_MenuItemTypeId",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_RestaurantTypes_ResturantTypeId",
                table: "Restaurants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantTypes",
                table: "RestaurantTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItemTypes",
                table: "MenuItemTypes");

            migrationBuilder.RenameTable(
                name: "RestaurantTypes",
                newName: "RestaurantType");

            migrationBuilder.RenameTable(
                name: "MenuItemTypes",
                newName: "MenuItemType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantType",
                table: "RestaurantType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItemType",
                table: "MenuItemType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_MenuItemType_MenuItemTypeId",
                table: "MenuItems",
                column: "MenuItemTypeId",
                principalTable: "MenuItemType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_RestaurantType_ResturantTypeId",
                table: "Restaurants",
                column: "ResturantTypeId",
                principalTable: "RestaurantType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
