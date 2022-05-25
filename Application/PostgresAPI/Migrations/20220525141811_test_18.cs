using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostgresAPI.Migrations
{
    public partial class test_18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 25, 14, 18, 11, 5, DateTimeKind.Utc).AddTicks(1325),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2022, 5, 25, 16, 13, 20, 334, DateTimeKind.Local).AddTicks(2781));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$TVxRzGFC.mANuCu.WFIMK.PJovOnL1y8fjOwxuZdp4VAPSOSy2oGC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$wdX0/Cn9Wvkti2uz0blsq.P.bNQlvuu9c5iAK8v9OTnoc0UImxscm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$AeYg1g3UjQF10HKzjX8m7.TFW5xy.ZbS3WEP9BkAOObb7nOFICcaG");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 25, 16, 13, 20, 334, DateTimeKind.Local).AddTicks(2781),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 5, 25, 14, 18, 11, 5, DateTimeKind.Utc).AddTicks(1325));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$lhlZBCBVW.z4YtkpNl0FqeyLhI8K7I0ept98/XC67AjPLQkQbpexi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$vzqlpyosswaR8CbEMeNx/OryFjxosM4dOyE/WIUQpHaPn38vmsdRi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$V1XneNM201GseyMKry.x3eHqmPj0Awbb1iJvsrum0XynnYXT4jIYW");
        }
    }
}
