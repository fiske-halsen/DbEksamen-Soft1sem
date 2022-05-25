using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostgresAPI.Migrations
{
    public partial class test_17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 25, 16, 13, 20, 334, DateTimeKind.Local).AddTicks(2781),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$lhlZBCBVW.z4YtkpNl0FqeyLhI8K7I0ept98/XC67AjPLQkQbpexi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$vzqlpyosswaR8CbEMeNx/OryFjxosM4dOyE/WIUQpHaPn38vmsdRi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$V1XneNM201GseyMKry.x3eHqmPj0Awbb1iJvsrum0XynnYXT4jIYW" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2022, 5, 25, 16, 13, 20, 334, DateTimeKind.Local).AddTicks(2781));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 5, 25, 14, 7, 49, 11, DateTimeKind.Utc).AddTicks(7619), "$2a$11$q6/kDrslWFhsO3OXuFAAnuad2FftT4CTsv7NAn.veTmb1L1CmH9JC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 5, 25, 14, 7, 49, 159, DateTimeKind.Utc).AddTicks(2311), "$2a$11$u3AgJWEqcTBSbcbzbY44iOIfcO6/6CMooICL90U6M31i2gmKrx3s." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 5, 25, 14, 7, 49, 310, DateTimeKind.Utc).AddTicks(5571), "$2a$11$/VTcL1t27rHg09Mir8gmLeu71KEjbuyebR0Y58Ri6RhGUZlw4G5Mu" });
        }
    }
}
