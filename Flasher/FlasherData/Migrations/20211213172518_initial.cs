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
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubjectDmId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Subjects_SubjectDmId",
                        column: x => x.SubjectDmId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Subjects = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_Subjects_Subjects",
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
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryDmId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flashcards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flashcards_Categories_CategoryDmId",
                        column: x => x.CategoryDmId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Test = table.Column<int>(type: "INTEGER", nullable: false),
                    FlashcardId = table.Column<int>(type: "INTEGER", nullable: false),
                    TestDmId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Tests_TestDmId",
                        column: x => x.TestDmId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectDmId", "SubjectId" },
                values: new object[] { 1, "Category1", null, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectDmId", "SubjectId" },
                values: new object[] { 2, "Category2", null, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectDmId", "SubjectId" },
                values: new object[] { 3, "Category3", null, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectDmId", "SubjectId" },
                values: new object[] { 4, "Category4", null, 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectDmId", "SubjectId" },
                values: new object[] { 5, "Category5", null, 2 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectDmId", "SubjectId" },
                values: new object[] { 6, "Category6", null, 2 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectDmId", "SubjectId" },
                values: new object[] { 7, "Category7", null, 2 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SubjectDmId", "SubjectId" },
                values: new object[] { 8, "Category8", null, 2 });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryDmId", "CategoryId", "Front", "Name", "Number" },
                values: new object[] { 8, false, "Back8", null, 4, "Front8", "Flashcard8", 0 });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryDmId", "CategoryId", "Front", "Name", "Number" },
                values: new object[] { 7, false, "Back7", null, 4, "Front7", "Flashcard7", 0 });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryDmId", "CategoryId", "Front", "Name", "Number" },
                values: new object[] { 6, false, "Back6", null, 3, "Front5", "Flashcard6", 0 });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryDmId", "CategoryId", "Front", "Name", "Number" },
                values: new object[] { 5, false, "Back5", null, 3, "Front5", "Flashcard5", 0 });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryDmId", "CategoryId", "Front", "Name", "Number" },
                values: new object[] { 4, false, "Back4", null, 2, "Front4", "Flashcard4", 0 });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryDmId", "CategoryId", "Front", "Name", "Number" },
                values: new object[] { 3, false, "Back3", null, 2, "Front3", "Flashcard3", 0 });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryDmId", "CategoryId", "Front", "Name", "Number" },
                values: new object[] { 2, false, "Back2", null, 1, "Front2", "Flashcard2", 0 });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "CategoryDmId", "CategoryId", "Front", "Name", "Number" },
                values: new object[] { 1, false, "Back1", null, 1, "Front1", "Flashcard1", 0 });

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

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SubjectDmId",
                table: "Categories",
                column: "SubjectDmId");

            migrationBuilder.CreateIndex(
                name: "IX_Flashcards_CategoryDmId",
                table: "Flashcards",
                column: "CategoryDmId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestDmId",
                table: "Questions",
                column: "TestDmId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_Subjects",
                table: "Tests",
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
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
