using Microsoft.EntityFrameworkCore.Migrations;

namespace DynamicSiteEntity.Migrations
{
    public partial class db34454dfffdfgf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentPage_Lang_LangId",
                table: "ContentPage");

            migrationBuilder.AlterColumn<int>(
                name: "LangId",
                table: "ContentPage",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentPage_Lang_LangId",
                table: "ContentPage",
                column: "LangId",
                principalTable: "Lang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentPage_Lang_LangId",
                table: "ContentPage");

            migrationBuilder.AlterColumn<int>(
                name: "LangId",
                table: "ContentPage",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ContentPage_Lang_LangId",
                table: "ContentPage",
                column: "LangId",
                principalTable: "Lang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
