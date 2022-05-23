using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostgresAPI.Migrations
{
    public partial class test_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RoleType",
                table: "Roles",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleType",
                value: "Customer");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoleType",
                value: "Owner");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RoleType",
                table: "Roles",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoleType",
                value: 1);
        }
    }
}
