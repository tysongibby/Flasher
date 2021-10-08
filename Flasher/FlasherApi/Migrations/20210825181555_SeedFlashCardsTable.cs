using Microsoft.EntityFrameworkCore.Migrations;

namespace FlasherApi.Migrations
{
    public partial class SeedFlashCardsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlashCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Front = table.Column<string>(type: "TEXT", nullable: false),
                    Back = table.Column<string>(type: "TEXT", nullable: false),
                    AnsweredCorrectly = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashCards", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "FlashCards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "Front" },
                values: new object[] { 1, false, "Back_1", "Front_1" });

            migrationBuilder.InsertData(
                table: "FlashCards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "Front" },
                values: new object[] { 2, false, "Back_2", "Front_2" });

            migrationBuilder.InsertData(
                table: "FlashCards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "Front" },
                values: new object[] { 3, false, "Back_3", "Front_3" });

            migrationBuilder.InsertData(
                table: "FlashCards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "Front" },
                values: new object[] { 4, false, "Back_4", "Front_4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlashCards");
        }
    }
}
