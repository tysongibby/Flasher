using Microsoft.EntityFrameworkCore.Migrations;

namespace FlasherApi.Migrations
{
    public partial class addedFlashCardSetModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlashCardSetId",
                table: "FlashCards",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FlashCardSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    SuperFlashCardSetId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashCardSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlashCardSet_FlashCardSet_SuperFlashCardSetId",
                        column: x => x.SuperFlashCardSetId,
                        principalTable: "FlashCardSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlashCards_FlashCardSetId",
                table: "FlashCards",
                column: "FlashCardSetId");

            migrationBuilder.CreateIndex(
                name: "IX_FlashCardSet_SuperFlashCardSetId",
                table: "FlashCardSet",
                column: "SuperFlashCardSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCards_FlashCardSet_FlashCardSetId",
                table: "FlashCards",
                column: "FlashCardSetId",
                principalTable: "FlashCardSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlashCards_FlashCardSet_FlashCardSetId",
                table: "FlashCards");

            migrationBuilder.DropTable(
                name: "FlashCardSet");

            migrationBuilder.DropIndex(
                name: "IX_FlashCards_FlashCardSetId",
                table: "FlashCards");

            migrationBuilder.DropColumn(
                name: "FlashCardSetId",
                table: "FlashCards");
        }
    }
}
