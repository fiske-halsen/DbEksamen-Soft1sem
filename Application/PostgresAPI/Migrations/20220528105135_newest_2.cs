using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostgresAPI.Migrations
{
    public partial class newest_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 28, 10, 51, 34, 675, DateTimeKind.Utc).AddTicks(3512),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 5, 28, 10, 26, 10, 471, DateTimeKind.Utc).AddTicks(7289));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "MenuItems",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 28, 10, 51, 34, 675, DateTimeKind.Utc).AddTicks(3882));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2022, 5, 28, 10, 51, 35, 359, DateTimeKind.Utc).AddTicks(9095));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2022, 5, 28, 10, 51, 35, 359, DateTimeKind.Utc).AddTicks(9099));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2022, 5, 28, 10, 51, 35, 359, DateTimeKind.Utc).AddTicks(9100));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2022, 5, 28, 10, 51, 35, 359, DateTimeKind.Utc).AddTicks(9101));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2022, 5, 28, 10, 51, 35, 359, DateTimeKind.Utc).AddTicks(9101));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2022, 5, 28, 10, 51, 35, 359, DateTimeKind.Utc).AddTicks(9102));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2022, 5, 28, 10, 51, 35, 359, DateTimeKind.Utc).AddTicks(9102));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2022, 5, 28, 10, 51, 35, 359, DateTimeKind.Utc).AddTicks(9103));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2022, 5, 28, 10, 51, 35, 359, DateTimeKind.Utc).AddTicks(9104));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2022, 5, 28, 10, 51, 35, 359, DateTimeKind.Utc).AddTicks(9104));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2022, 5, 28, 10, 51, 35, 359, DateTimeKind.Utc).AddTicks(9105));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "UpdatedAt",
                value: new DateTime(2022, 5, 28, 10, 51, 35, 359, DateTimeKind.Utc).AddTicks(9105));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "UpdatedAt",
                value: new DateTime(2022, 5, 28, 10, 51, 35, 359, DateTimeKind.Utc).AddTicks(9106));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "UpdatedAt",
                value: new DateTime(2022, 5, 28, 10, 51, 35, 359, DateTimeKind.Utc).AddTicks(9106));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "UpdatedAt",
                value: new DateTime(2022, 5, 28, 10, 51, 35, 359, DateTimeKind.Utc).AddTicks(9107));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "UpdatedAt",
                value: new DateTime(2022, 5, 28, 10, 51, 35, 359, DateTimeKind.Utc).AddTicks(9107));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 17,
                column: "UpdatedAt",
                value: new DateTime(2022, 5, 28, 10, 51, 35, 359, DateTimeKind.Utc).AddTicks(9108));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 18,
                column: "UpdatedAt",
                value: new DateTime(2022, 5, 28, 10, 51, 35, 359, DateTimeKind.Utc).AddTicks(9109));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 19,
                column: "UpdatedAt",
                value: new DateTime(2022, 5, 28, 10, 51, 35, 359, DateTimeKind.Utc).AddTicks(9109));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 20,
                column: "UpdatedAt",
                value: new DateTime(2022, 5, 28, 10, 51, 35, 359, DateTimeKind.Utc).AddTicks(9110));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 5, 28, 10, 51, 34, 675, DateTimeKind.Utc).AddTicks(4149), "$2a$11$1MpO/2rE.1ne6fb/1y3PHuJNGgoqQlTmJu1VFrCLTz9S2LAHOanUC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 5, 28, 10, 51, 34, 824, DateTimeKind.Utc).AddTicks(297), "$2a$11$FmAOIZgJGuZuz3rq7TfVHODqYenavrJi6UTu9XgBrprRqod4yY48W" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 5, 28, 10, 51, 35, 73, DateTimeKind.Utc).AddTicks(8750), "$2a$11$4kXOj0M.xhoRE3jvvIr5ouwW2HZuIG6WLVTRURrBxTa07HF.o9Hyi" });

            migrationBuilder.Sql("CREATE OR REPLACE FUNCTION update_updatedAt_menuItem() RETURNS TRIGGER LANGUAGE PLPGSQL AS $$ BEGIN NEW.\"UpdatedAt\" = now(); RETURN NEW; END; $$");
            migrationBuilder.Sql("create or REPLACE TRIGGER updateAt_trigger before UPDATE ON public.\"MenuItems\" FOR EACH ROW EXECUTE PROCEDURE update_updatedAt_menuItem();");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "MenuItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 28, 10, 26, 10, 471, DateTimeKind.Utc).AddTicks(7289),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 5, 28, 10, 51, 34, 675, DateTimeKind.Utc).AddTicks(3512));

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
    }
}
