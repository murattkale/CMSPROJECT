using Microsoft.EntityFrameworkCore.Migrations;

namespace DynamicSiteEntity.Migrations
{
    public partial class db34553635dfg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMap",
                table: "ContentPage",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMap",
                table: "ContentPage");
        }
    }
}
