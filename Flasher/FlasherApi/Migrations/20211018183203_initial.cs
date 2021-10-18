using Microsoft.EntityFrameworkCore.Migrations;

namespace FlasherApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Supersets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supersets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlashCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Front = table.Column<string>(type: "TEXT", nullable: false),
                    Back = table.Column<string>(type: "TEXT", nullable: false),
                    AnsweredCorrectly = table.Column<bool>(type: "INTEGER", nullable: false),
                    Superset = table.Column<string>(type: "TEXT", nullable: false),
                    Set = table.Column<string>(type: "TEXT", nullable: true),
                    SupersetId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlashCards_Supersets_SupersetId",
                        column: x => x.SupersetId,
                        principalTable: "Supersets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Supersets",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "Superset1" });

            migrationBuilder.InsertData(
                table: "Supersets",
                columns: new[] { "Id", "Title" },
                values: new object[] { 2, "Superset2" });

            migrationBuilder.InsertData(
                table: "Supersets",
                columns: new[] { "Id", "Title" },
                values: new object[] { 3, "Superset3" });

            migrationBuilder.InsertData(
                table: "Supersets",
                columns: new[] { "Id", "Title" },
                values: new object[] { 4, "Superset4" });

            migrationBuilder.InsertData(
                table: "Supersets",
                columns: new[] { "Id", "Title" },
                values: new object[] { 5, "Superset5" });

            migrationBuilder.InsertData(
                table: "Supersets",
                columns: new[] { "Id", "Title" },
                values: new object[] { 6, "Superset6" });

            migrationBuilder.InsertData(
                table: "Supersets",
                columns: new[] { "Id", "Title" },
                values: new object[] { 7, "Superset7" });

            migrationBuilder.InsertData(
                table: "Supersets",
                columns: new[] { "Id", "Title" },
                values: new object[] { 8, "Superset8" });

            migrationBuilder.InsertData(
                table: "FlashCards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "Front", "Set", "Superset", "SupersetId", "Title" },
                values: new object[] { 1, false, "Back1", "Front1", "Set1", "Superset1", 1, "FlashCard1" });

            migrationBuilder.InsertData(
                table: "FlashCards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "Front", "Set", "Superset", "SupersetId", "Title" },
                values: new object[] { 2, false, "Back2", "Front2", "Set1", "Superset1", 1, "FlashCard2" });

            migrationBuilder.InsertData(
                table: "FlashCards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "Front", "Set", "Superset", "SupersetId", "Title" },
                values: new object[] { 3, false, "Back3", "Front3", "Set2", "Superset1", 1, "FlashCard3" });

            migrationBuilder.InsertData(
                table: "FlashCards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "Front", "Set", "Superset", "SupersetId", "Title" },
                values: new object[] { 4, false, "Back4", "Front4", "Set2", "Superset1", 1, "FlashCard4" });

            migrationBuilder.InsertData(
                table: "FlashCards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "Front", "Set", "Superset", "SupersetId", "Title" },
                values: new object[] { 5, false, "Back5", "Front5", "Set3", "Superset2", 2, "FlashCard5" });

            migrationBuilder.InsertData(
                table: "FlashCards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "Front", "Set", "Superset", "SupersetId", "Title" },
                values: new object[] { 6, false, "Back6", "Front5", "Set3", "Superset2", 2, "FlashCard6" });

            migrationBuilder.InsertData(
                table: "FlashCards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "Front", "Set", "Superset", "SupersetId", "Title" },
                values: new object[] { 7, false, "Back7", "Front7", "Set4", "Superset2", 2, "FlashCard7" });

            migrationBuilder.InsertData(
                table: "FlashCards",
                columns: new[] { "Id", "AnsweredCorrectly", "Back", "Front", "Set", "Superset", "SupersetId", "Title" },
                values: new object[] { 8, false, "Back8", "Front8", "Set4", "Superset2", 2, "FlashCard8" });

            migrationBuilder.CreateIndex(
                name: "IX_FlashCards_SupersetId",
                table: "FlashCards",
                column: "SupersetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlashCards");

            migrationBuilder.DropTable(
                name: "Supersets");
        }
    }
}
