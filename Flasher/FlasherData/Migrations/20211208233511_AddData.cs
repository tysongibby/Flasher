using Microsoft.EntityFrameworkCore.Migrations;

namespace FlasherData.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "SubjectId", "Title" },
                values: new object[] { 1, 1, "Category1" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "SubjectId", "Title" },
                values: new object[] { 2, 1, "Category2" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "SubjectId", "Title" },
                values: new object[] { 3, 1, "Category3" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "SubjectId", "Title" },
                values: new object[] { 4, 1, "Category4" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "SubjectId", "Title" },
                values: new object[] { 5, 2, "Category5" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "SubjectId", "Title" },
                values: new object[] { 6, 2, "Category6" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "SubjectId", "Title" },
                values: new object[] { 7, 2, "Category7" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "SubjectId", "Title" },
                values: new object[] { 8, 2, "Category8" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryId", "Front", "Title" },
                values: new object[] { 1, false, "Back1", 1, "Front1", "Flashcard1" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryId", "Front", "Title" },
                values: new object[] { 2, false, "Back2", 1, "Front2", "Flashcard2" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryId", "Front", "Title" },
                values: new object[] { 3, false, "Back3", 2, "Front3", "Flashcard3" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryId", "Front", "Title" },
                values: new object[] { 4, false, "Back4", 2, "Front4", "Flashcard4" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryId", "Front", "Title" },
                values: new object[] { 5, false, "Back5", 3, "Front5", "Flashcard5" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryId", "Front", "Title" },
                values: new object[] { 6, false, "Back6", 3, "Front5", "Flashcard6" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryId", "Front", "Title" },
                values: new object[] { 7, false, "Back7", 4, "Front7", "Flashcard7" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryId", "Front", "Title" },
                values: new object[] { 8, false, "Back8", 4, "Front8", "Flashcard8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Flashcards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flashcards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Flashcards",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Flashcards",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Flashcards",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Flashcards",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Flashcards",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Flashcards",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
