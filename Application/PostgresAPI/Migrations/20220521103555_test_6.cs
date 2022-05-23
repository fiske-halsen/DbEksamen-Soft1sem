using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PostgresAPI.Migrations
{
    public partial class test_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResturantType",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "MenuItemType",
                table: "MenuItems");

            migrationBuilder.AddColumn<int>(
                name: "ResturantTypeId",
                table: "Restaurants",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MenuItemTypeId",
                table: "MenuItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MenuItemType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MenuItemTypeChoice = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RestaurantTypeChoice = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantType", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MenuItemType",
                columns: new[] { "Id", "MenuItemTypeChoice" },
                values: new object[,]
                {
                    { 1, "AddOn" },
                    { 2, "Dessert" },
                    { 3, "Food" },
                    { 4, "Drink" }
                });

            migrationBuilder.InsertData(
                table: "RestaurantType",
                columns: new[] { "Id", "RestaurantTypeChoice" },
                values: new object[,]
                {
                    { 1, "Salat" },
                    { 2, "Cafe" },
                    { 3, "Vietnamese" },
                    { 4, "Vegan" },
                    { 5, "Mexican" },
                    { 6, "Bagel" },
                    { 7, "Bar" },
                    { 8, "Burger" },
                    { 9, "Chinese" },
                    { 10, "Danish" },
                    { 11, "Dessert" },
                    { 12, "Icecream" },
                    { 13, "Indian" },
                    { 14, "Italian" },
                    { 15, "Pizza" },
                    { 16, "Sushi" },
                    { 17, "Sandwich" },
                    { 18, "Thai" }
                });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "MenuItemTypeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "MenuItemTypeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "MenuItemTypeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "MenuItemTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "MenuItemTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "MenuItemTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "MenuItemTypeId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "MenuItemTypeId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "MenuItemTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "MenuItemTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "MenuItemTypeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "MenuItemTypeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "MenuItemTypeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "MenuItemTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "MenuItemTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "MenuItemTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 17,
                column: "MenuItemTypeId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 18,
                column: "MenuItemTypeId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 19,
                column: "MenuItemTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 20,
                column: "MenuItemTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "ResturantTypeId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "ResturantTypeId",
                value: 16);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_ResturantTypeId",
                table: "Restaurants",
                column: "ResturantTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuItemTypeId",
                table: "MenuItems",
                column: "MenuItemTypeId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_MenuItemType_MenuItemTypeId",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_RestaurantType_ResturantTypeId",
                table: "Restaurants");

            migrationBuilder.DropTable(
                name: "MenuItemType");

            migrationBuilder.DropTable(
                name: "RestaurantType");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_ResturantTypeId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_MenuItemTypeId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "ResturantTypeId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "MenuItemTypeId",
                table: "MenuItems");

            migrationBuilder.AddColumn<string>(
                name: "ResturantType",
                table: "Restaurants",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MenuItemType",
                table: "MenuItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "MenuItemType",
                value: "Food");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "MenuItemType",
                value: "Food");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "MenuItemType",
                value: "Food");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "MenuItemType",
                value: "Dessert");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "MenuItemType",
                value: "Dessert");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "MenuItemType",
                value: "Dessert");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "MenuItemType",
                value: "Drink");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "MenuItemType",
                value: "Drink");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "MenuItemType",
                value: "AddOn");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "MenuItemType",
                value: "AddOn");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "MenuItemType",
                value: "Food");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "MenuItemType",
                value: "Food");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "MenuItemType",
                value: "Food");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "MenuItemType",
                value: "Dessert");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "MenuItemType",
                value: "Dessert");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "MenuItemType",
                value: "Dessert");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 17,
                column: "MenuItemType",
                value: "Drink");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 18,
                column: "MenuItemType",
                value: "Drink");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 19,
                column: "MenuItemType",
                value: "AddOn");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 20,
                column: "MenuItemType",
                value: "AddOn");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "ResturantType",
                value: "Pizza");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "ResturantType",
                value: "Sushi");
        }
    }
}
