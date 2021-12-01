using Microsoft.EntityFrameworkCore.Migrations;

namespace FlasherData.Migrations
{
    public partial class latest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlashCards_Sets_SetId",
                table: "FlashCards");

            migrationBuilder.DropForeignKey(
                name: "FK_FlashCards_Supersets_SupersetId",
                table: "FlashCards");

            migrationBuilder.DropIndex(
                name: "IX_FlashCards_SetId",
                table: "FlashCards");

            migrationBuilder.DropIndex(
                name: "IX_FlashCards_SupersetId",
                table: "FlashCards");

            migrationBuilder.AddColumn<int>(
                name: "SetModelId",
                table: "FlashCards",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupersetModelId",
                table: "FlashCards",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlashCards_SetModelId",
                table: "FlashCards",
                column: "SetModelId");

            migrationBuilder.CreateIndex(
                name: "IX_FlashCards_SupersetModelId",
                table: "FlashCards",
                column: "SupersetModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCards_Sets_SetModelId",
                table: "FlashCards",
                column: "SetModelId",
                principalTable: "Sets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCards_Supersets_SupersetModelId",
                table: "FlashCards",
                column: "SupersetModelId",
                principalTable: "Supersets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlashCards_Sets_SetModelId",
                table: "FlashCards");

            migrationBuilder.DropForeignKey(
                name: "FK_FlashCards_Supersets_SupersetModelId",
                table: "FlashCards");

            migrationBuilder.DropIndex(
                name: "IX_FlashCards_SetModelId",
                table: "FlashCards");

            migrationBuilder.DropIndex(
                name: "IX_FlashCards_SupersetModelId",
                table: "FlashCards");

            migrationBuilder.DropColumn(
                name: "SetModelId",
                table: "FlashCards");

            migrationBuilder.DropColumn(
                name: "SupersetModelId",
                table: "FlashCards");

            migrationBuilder.CreateIndex(
                name: "IX_FlashCards_SetId",
                table: "FlashCards",
                column: "SetId");

            migrationBuilder.CreateIndex(
                name: "IX_FlashCards_SupersetId",
                table: "FlashCards",
                column: "SupersetId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCards_Sets_SetId",
                table: "FlashCards",
                column: "SetId",
                principalTable: "Sets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCards_Supersets_SupersetId",
                table: "FlashCards",
                column: "SupersetId",
                principalTable: "Supersets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
