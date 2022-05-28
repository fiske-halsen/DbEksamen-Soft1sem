using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostgresAPI.Migrations
{
    public partial class test_19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 25, 14, 19, 15, 233, DateTimeKind.Utc).AddTicks(9869),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 5, 25, 14, 18, 11, 5, DateTimeKind.Utc).AddTicks(1325));

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 25, 14, 18, 11, 5, DateTimeKind.Utc).AddTicks(1325),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 5, 25, 14, 19, 15, 233, DateTimeKind.Utc).AddTicks(9869));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$TVxRzGFC.mANuCu.WFIMK.PJovOnL1y8fjOwxuZdp4VAPSOSy2oGC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$wdX0/Cn9Wvkti2uz0blsq.P.bNQlvuu9c5iAK8v9OTnoc0UImxscm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$AeYg1g3UjQF10HKzjX8m7.TFW5xy.ZbS3WEP9BkAOObb7nOFICcaG" });
        }
    }
}
