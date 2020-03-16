using Microsoft.EntityFrameworkCore.Migrations;

namespace DynamicSiteEntity.Migrations
{
    public partial class db77 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsForm",
                table: "ContentPage",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsGallery",
                table: "ContentPage",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsForm",
                table: "ContentPage");

            migrationBuilder.DropColumn(
                name: "IsGallery",
                table: "ContentPage");
        }
    }
}
