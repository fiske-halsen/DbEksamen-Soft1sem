using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostgresAPI.Migrations
{
    public partial class newest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 28, 10, 26, 10, 471, DateTimeKind.Utc).AddTicks(7289),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 5, 25, 14, 19, 15, 233, DateTimeKind.Utc).AddTicks(9869));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "StreetName",
                value: "Skovvej");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "StreetName",
                value: "Hovmarksvej");

            migrationBuilder.UpdateData(
                table: "CityInfos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "ZipCode" },
                values: new object[] { "Gentofte", "2920" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 5, 28, 10, 26, 10, 471, DateTimeKind.Utc).AddTicks(7632), "$2a$11$A3NfmwsL1FOfWfI6O5jMBelwbYuJ0nLkwuZtJ6MeQAG22gnNOwqmq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 5, 28, 10, 26, 10, 582, DateTimeKind.Utc).AddTicks(7996), "$2a$11$IDNgvNGnQKJNoQrp3cqn..UBkF3Su/RbJsKatAoBaw.9WwbzntIA6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 5, 28, 10, 26, 10, 697, DateTimeKind.Utc).AddTicks(5217), "$2a$11$5d/70vDxe6ESkl8Xg0tzku6UBbqeOLlZKahx3/FHojzv2P1lwutca" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 25, 14, 19, 15, 233, DateTimeKind.Utc).AddTicks(9869),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 5, 28, 10, 26, 10, 471, DateTimeKind.Utc).AddTicks(7289));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "StreetName",
                value: "PusherStreet");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "StreetName",
                value: "NemoLand");

            migrationBuilder.UpdateData(
                table: "CityInfos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "ZipCode" },
                values: new object[] { "Staden", "2500" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 5, 25, 14, 19, 15, 234, DateTimeKind.Utc).AddTicks(386), "$2a$11$fES.A9PJsTr8zw3w2SF48uO7W/QsI/fZRdWTIJdErLorBQdSWML9i" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 5, 25, 14, 19, 15, 396, DateTimeKind.Utc).AddTicks(7709), "$2a$11$hp.QyydIaq.voe28X/IPT.Dd7nRvbdfF22JrYgbdvOIt2JqQihgvm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 5, 25, 14, 19, 15, 553, DateTimeKind.Utc).AddTicks(7292), "$2a$11$d.I63aIEKX261sNi9ysLd.Z1iSyImCihiUt/slocbPobssZV/fKBe" });


            migrationBuilder.Sql("Select * from Users");



        }
    }
}
