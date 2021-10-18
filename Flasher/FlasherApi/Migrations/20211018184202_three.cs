using Microsoft.EntityFrameworkCore.Migrations;

namespace FlasherApi.Migrations
{
    public partial class three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SetId",
                table: "FlashCards",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Sets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Sets",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "Set1" });

            migrationBuilder.InsertData(
                table: "Sets",
                columns: new[] { "Id", "Title" },
                values: new object[] { 2, "Set2" });

            migrationBuilder.InsertData(
                table: "Sets",
                columns: new[] { "Id", "Title" },
                values: new object[] { 3, "Set3" });

            migrationBuilder.InsertData(
                table: "Sets",
                columns: new[] { "Id", "Title" },
                values: new object[] { 4, "Set4" });

            migrationBuilder.InsertData(
                table: "Sets",
                columns: new[] { "Id", "Title" },
                values: new object[] { 5, "Set5" });

            migrationBuilder.InsertData(
                table: "Sets",
                columns: new[] { "Id", "Title" },
                values: new object[] { 6, "Set6" });

            migrationBuilder.InsertData(
                table: "Sets",
                columns: new[] { "Id", "Title" },
                values: new object[] { 7, "Set7" });

            migrationBuilder.InsertData(
                table: "Sets",
                columns: new[] { "Id", "Title" },
                values: new object[] { 8, "Set8" });

            migrationBuilder.UpdateData(
                table: "FlashCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "SetId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "FlashCards",
                keyColumn: "Id",
                keyValue: 2,
                column: "SetId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "FlashCards",
                keyColumn: "Id",
                keyValue: 3,
                column: "SetId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "FlashCards",
                keyColumn: "Id",
                keyValue: 4,
                column: "SetId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "FlashCards",
                keyColumn: "Id",
                keyValue: 5,
                column: "SetId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "FlashCards",
                keyColumn: "Id",
                keyValue: 6,
                column: "SetId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "FlashCards",
                keyColumn: "Id",
                keyValue: 7,
                column: "SetId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "FlashCards",
                keyColumn: "Id",
                keyValue: 8,
                column: "SetId",
                value: 4);

            migrationBuilder.CreateIndex(
                name: "IX_FlashCards_SetId",
                table: "FlashCards",
                column: "SetId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCards_Sets_SetId",
                table: "FlashCards",
                column: "SetId",
                principalTable: "Sets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlashCards_Sets_SetId",
                table: "FlashCards");

            migrationBuilder.DropTable(
                name: "Sets");

            migrationBuilder.DropIndex(
                name: "IX_FlashCards_SetId",
                table: "FlashCards");

            migrationBuilder.DropColumn(
                name: "SetId",
                table: "FlashCards");
        }
    }
}
