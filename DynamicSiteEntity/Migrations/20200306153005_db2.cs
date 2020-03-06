using Microsoft.EntityFrameworkCore.Migrations;

namespace DynamicSiteEntity.Migrations
{
    public partial class db2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "ContentPage");

            migrationBuilder.AddColumn<int>(
                name: "ContentOrderNo",
                table: "ContentPage",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContentPageId",
                table: "ContentPage",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContentPage_ContentPageId",
                table: "ContentPage",
                column: "ContentPageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentPage_ContentPage_ContentPageId",
                table: "ContentPage",
                column: "ContentPageId",
                principalTable: "ContentPage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentPage_ContentPage_ContentPageId",
                table: "ContentPage");

            migrationBuilder.DropIndex(
                name: "IX_ContentPage_ContentPageId",
                table: "ContentPage");

            migrationBuilder.DropColumn(
                name: "ContentOrderNo",
                table: "ContentPage");

            migrationBuilder.DropColumn(
                name: "ContentPageId",
                table: "ContentPage");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "ContentPage",
                type: "integer",
                nullable: true);
        }
    }
}
