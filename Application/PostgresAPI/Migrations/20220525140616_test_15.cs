using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostgresAPI.Migrations
{
    public partial class test_15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 5, 25, 16, 6, 15, 435, DateTimeKind.Local).AddTicks(8479), "$2a$11$LWWzzbT6xDHDAwuIa/cTTOU3Z3Cwcg0NoxAgB/IyOl0I2UCPTdycm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 5, 25, 16, 6, 15, 588, DateTimeKind.Local).AddTicks(404), "$2a$11$C/6pZkt8wObK1VhDT7L6hecdb.0cE4wxK0LAhnTCJXWT2G49Nwcvq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 5, 25, 16, 6, 15, 749, DateTimeKind.Local).AddTicks(3114), "$2a$11$JGStK89wVx6yS76rAKmaPuTn3qLKKD5taCL8irqKEfeJ30wFBMg12" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$hZ2GQezcpkISyc7tyK/Xie6LgO7C2GJNIiehQP1XkeBESOR.lDK0G");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$jTcBqoQvJlxl7QmcUELQU.Uys74mXPGYAjnPLgj.MCyMdscmabB4S");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$U6XaHHMKvhCe.DGi2PAvnO/.qm9hqzJoi7G8etTD0RxeYD7HXN6lG");
        }
    }
}
