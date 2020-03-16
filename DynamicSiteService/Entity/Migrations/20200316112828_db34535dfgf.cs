using Microsoft.EntityFrameworkCore.Migrations;

namespace DynamicSiteEntity.Migrations
{
    public partial class db34535dfgf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tumblar",
                table: "SiteConfig");

            migrationBuilder.AddColumn<string>(
                name: "Tumblr",
                table: "SiteConfig",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tumblr",
                table: "SiteConfig");

            migrationBuilder.AddColumn<string>(
                name: "Tumblar",
                table: "SiteConfig",
                type: "text",
                nullable: true);
        }
    }
}
