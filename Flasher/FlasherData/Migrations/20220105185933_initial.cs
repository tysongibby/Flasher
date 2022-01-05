using Microsoft.EntityFrameworkCore.Migrations;

namespace FlasherData.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flashcards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Front = table.Column<string>(type: "TEXT", nullable: false),
                    Back = table.Column<string>(type: "TEXT", nullable: false),
                    AnsweredCorrectly = table.Column<bool>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flashcards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flashcards_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    AnsweredCorrectly = table.Column<bool>(type: "INTEGER", nullable: false),
                    TestId = table.Column<int>(type: "INTEGER", nullable: false),
                    FlashcardId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Subject_1" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Subject_2" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Subject_3" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Subject_4" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 1, "Category_1", 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 2, "Category_2", 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 3, "Category_3", 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 4, "Category_4", 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 5, "Category_5", 2 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 6, "Category_6", 2 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 7, "Category_7", 2 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 8, "Category_8", 2 });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 1, "Test_1", 1 });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 2, "Test_2", 2 });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 3, "Test_3", 3 });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 4, "Test_4", 4 });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 1, false, "Back_1", 1, "Front_1", "Flashcard_1" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 2, false, "Back_2", 1, "Front_2", "Flashcard_2" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 3, false, "Back_3", 2, "Front_3", "Flashcard_3" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 4, false, "Back_4", 2, "Front_4", "Flashcard_4" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 5, false, "Back_5", 3, "Front_5", "Flashcard_5" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 6, false, "Back_6", 3, "Front_5", "Flashcard_6" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 7, false, "Back_7", 4, "Front_7", "Flashcard_7" });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryId", "Front", "Name" },
                values: new object[] { 8, false, "Back_8", 4, "Front_8", "Flashcard_8" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AnsweredCorrectly", "FlashcardId", "Number", "TestId" },
                values: new object[] { 1, false, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AnsweredCorrectly", "FlashcardId", "Number", "TestId" },
                values: new object[] { 2, false, 2, 2, 2 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AnsweredCorrectly", "FlashcardId", "Number", "TestId" },
                values: new object[] { 3, false, 3, 3, 3 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AnsweredCorrectly", "FlashcardId", "Number", "TestId" },
                values: new object[] { 4, false, 4, 4, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SubjectId",
                table: "Categories",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Flashcards_CategoryId",
                table: "Flashcards",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestId",
                table: "Questions",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_SubjectId",
                table: "Tests",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flashcards");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
