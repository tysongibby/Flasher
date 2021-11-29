using Microsoft.EntityFrameworkCore.Migrations;

namespace FlasherData.Migrations
{
    public partial class updateSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 1,
                column: "SupersetId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 2,
                column: "SupersetId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 3,
                column: "SupersetId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 4,
                column: "SupersetId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 5,
                column: "SupersetId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 6,
                column: "SupersetId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 7,
                column: "SupersetId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 8,
                column: "SupersetId",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 1,
                column: "SupersetId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 2,
                column: "SupersetId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 3,
                column: "SupersetId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 4,
                column: "SupersetId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 5,
                column: "SupersetId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 6,
                column: "SupersetId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 7,
                column: "SupersetId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 8,
                column: "SupersetId",
                value: 0);
        }
    }
}
