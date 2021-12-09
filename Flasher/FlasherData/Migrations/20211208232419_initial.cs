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
                    Title = table.Column<string>(type: "TEXT", nullable: false)
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
                    Title = table.Column<string>(type: "TEXT", nullable: false),
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
                name: "Flashcards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "Subject1" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Title" },
                values: new object[] { 2, "Subject2" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Title" },
                values: new object[] { 3, "Subject3" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Title" },
                values: new object[] { 4, "Subject4" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Title" },
                values: new object[] { 5, "Subject5" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Title" },
                values: new object[] { 6, "Subject6" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Title" },
                values: new object[] { 7, "Subject7" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Title" },
                values: new object[] { 8, "Subject8" });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SubjectId",
                table: "Categories",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Flashcards_CategoryId",
                table: "Flashcards",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flashcards");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
