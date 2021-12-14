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
                name: "Test",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Subjects = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Test_Subjects_Subjects",
                        column: x => x.Subjects,
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
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
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
                    AnsweredCorrectly = table.Column<bool>(type: "INTEGER", nullable: false),
                    Test = table.Column<int>(type: "INTEGER", nullable: false),
                    FlashcardId = table.Column<int>(type: "INTEGER", nullable: false),
                    TestId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Test_TestId",
                        column: x => x.TestId,
                        principalTable: "Test",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Subject1" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Subject2" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Subject3" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Subject4" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Subject5" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Subject6" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "Subject7" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8, "Subject8" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 1, "Category1", 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 2, "Category2", 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 3, "Category3", 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 4, "Category4", 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 5, "Category5", 2 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 6, "Category6", 2 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 7, "Category7", 2 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 8, "Category8", 2 });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryId", "Front", "Name", "Number" },
                values: new object[] { 1, false, "Back1", 1, "Front1", "Flashcard1", 0 });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryId", "Front", "Name", "Number" },
                values: new object[] { 2, false, "Back2", 1, "Front2", "Flashcard2", 0 });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryId", "Front", "Name", "Number" },
                values: new object[] { 3, false, "Back3", 2, "Front3", "Flashcard3", 0 });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryId", "Front", "Name", "Number" },
                values: new object[] { 4, false, "Back4", 2, "Front4", "Flashcard4", 0 });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryId", "Front", "Name", "Number" },
                values: new object[] { 5, false, "Back5", 3, "Front5", "Flashcard5", 0 });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryId", "Front", "Name", "Number" },
                values: new object[] { 6, false, "Back6", 3, "Front5", "Flashcard6", 0 });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryId", "Front", "Name", "Number" },
                values: new object[] { 7, false, "Back7", 4, "Front7", "Flashcard7", 0 });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryId", "Front", "Name", "Number" },
                values: new object[] { 8, false, "Back8", 4, "Front8", "Flashcard8", 0 });

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
                name: "IX_Test_Subjects",
                table: "Test",
                column: "Subjects");
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
                name: "Test");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
