using Microsoft.EntityFrameworkCore.Migrations;

namespace DynamicSiteEntity.Migrations
{
    public partial class db2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KurumId",
                table: "ContentPage");

            migrationBuilder.DropColumn(
                name: "SubeId",
                table: "ContentPage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KurumId",
                table: "ContentPage",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubeId",
                table: "ContentPage",
                type: "integer",
                nullable: true);
        }
    }
}
