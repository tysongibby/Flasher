using Microsoft.EntityFrameworkCore.Migrations;

namespace FlasherApi.Migrations
{
    public partial class UpdatedFlashCardSetModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlashCardSet_FlashCardSet_SuperFlashCardSetId",
                table: "FlashCardSet");

            migrationBuilder.RenameColumn(
                name: "SuperFlashCardSetId",
                table: "FlashCardSet",
                newName: "FlashCardSupersetId");

            migrationBuilder.RenameIndex(
                name: "IX_FlashCardSet_SuperFlashCardSetId",
                table: "FlashCardSet",
                newName: "IX_FlashCardSet_FlashCardSupersetId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCardSet_FlashCardSet_FlashCardSupersetId",
                table: "FlashCardSet",
                column: "FlashCardSupersetId",
                principalTable: "FlashCardSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlashCardSet_FlashCardSet_FlashCardSupersetId",
                table: "FlashCardSet");

            migrationBuilder.RenameColumn(
                name: "FlashCardSupersetId",
                table: "FlashCardSet",
                newName: "SuperFlashCardSetId");

            migrationBuilder.RenameIndex(
                name: "IX_FlashCardSet_FlashCardSupersetId",
                table: "FlashCardSet",
                newName: "IX_FlashCardSet_SuperFlashCardSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCardSet_FlashCardSet_SuperFlashCardSetId",
                table: "FlashCardSet",
                column: "SuperFlashCardSetId",
                principalTable: "FlashCardSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
