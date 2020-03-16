using Microsoft.EntityFrameworkCore.Migrations;

namespace DynamicSiteEntity.Migrations
{
    public partial class db3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResimLink",
                table: "ContentPage",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoLink",
                table: "ContentPage",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResimLink",
                table: "ContentPage");

            migrationBuilder.DropColumn(
                name: "VideoLink",
                table: "ContentPage");
        }
    }
}
