using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostgresAPI.Migrations
{
    public partial class test_16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
