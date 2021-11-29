using Microsoft.EntityFrameworkCore.Migrations;

namespace FlasherData.Migrations
{
    public partial class updateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlashCards_Sets_SetId",
                table: "FlashCards");

            migrationBuilder.DropColumn(
                name: "Set",
                table: "FlashCards");

            migrationBuilder.DropColumn(
                name: "Superset",
                table: "FlashCards");

            migrationBuilder.AddColumn<int>(
                name: "SupersetId",
                table: "Sets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SetId",
                table: "FlashCards",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCards_Sets_SetId",
                table: "FlashCards",
                column: "SetId",
                principalTable: "Sets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlashCards_Sets_SetId",
                table: "FlashCards");

            migrationBuilder.DropColumn(
                name: "SupersetId",
                table: "Sets");

            migrationBuilder.AlterColumn<int>(
                name: "SetId",
                table: "FlashCards",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Set",
                table: "FlashCards",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Superset",
                table: "FlashCards",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "FlashCards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Set", "Superset" },
                values: new object[] { "Set1", "Superset1" });

            migrationBuilder.UpdateData(
                table: "FlashCards",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Set", "Superset" },
                values: new object[] { "Set1", "Superset1" });

            migrationBuilder.UpdateData(
                table: "FlashCards",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Set", "Superset" },
                values: new object[] { "Set2", "Superset1" });

            migrationBuilder.UpdateData(
                table: "FlashCards",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Set", "Superset" },
                values: new object[] { "Set2", "Superset1" });

            migrationBuilder.UpdateData(
                table: "FlashCards",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Set", "Superset" },
                values: new object[] { "Set3", "Superset2" });

            migrationBuilder.UpdateData(
                table: "FlashCards",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Set", "Superset" },
                values: new object[] { "Set3", "Superset2" });

            migrationBuilder.UpdateData(
                table: "FlashCards",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Set", "Superset" },
                values: new object[] { "Set4", "Superset2" });

            migrationBuilder.UpdateData(
                table: "FlashCards",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Set", "Superset" },
                values: new object[] { "Set4", "Superset2" });

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCards_Sets_SetId",
                table: "FlashCards",
                column: "SetId",
                principalTable: "Sets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
