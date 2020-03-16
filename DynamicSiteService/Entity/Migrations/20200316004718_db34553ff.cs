using Microsoft.EntityFrameworkCore.Migrations;

namespace DynamicSiteEntity.Migrations
{
    public partial class db34553ff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "SiteConfig",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GooglePlus",
                table: "SiteConfig",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "SiteConfig",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tumblar",
                table: "SiteConfig",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "SiteConfig",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Youtube",
                table: "SiteConfig",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "SiteConfig");

            migrationBuilder.DropColumn(
                name: "GooglePlus",
                table: "SiteConfig");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "SiteConfig");

            migrationBuilder.DropColumn(
                name: "Tumblar",
                table: "SiteConfig");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "SiteConfig");

            migrationBuilder.DropColumn(
                name: "Youtube",
                table: "SiteConfig");
        }
    }
}
