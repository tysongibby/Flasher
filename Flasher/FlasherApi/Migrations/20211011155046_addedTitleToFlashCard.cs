using Microsoft.EntityFrameworkCore.Migrations;

namespace FlasherApi.Migrations
{
    public partial class addedTitleToFlashCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "FlashCards",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "FlashCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Title1");

            migrationBuilder.UpdateData(
                table: "FlashCards",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Title2");

            migrationBuilder.UpdateData(
                table: "FlashCards",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "Title3");

            migrationBuilder.UpdateData(
                table: "FlashCards",
                keyColumn: "Id",
                keyValue: 4,
                column: "Title",
                value: "Title4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "FlashCards");
        }
    }
}
