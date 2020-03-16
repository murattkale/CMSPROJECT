using Microsoft.EntityFrameworkCore.Migrations;

namespace DynamicSiteEntity.Migrations
{
    public partial class db345345f : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "SiteConfig",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "SiteConfig",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "SiteConfig",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmtpHost",
                table: "SiteConfig",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmtpMail",
                table: "SiteConfig",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmtpMailPass",
                table: "SiteConfig",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmtpPort",
                table: "SiteConfig",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SmtpSSL",
                table: "SiteConfig",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "SiteConfig");

            migrationBuilder.DropColumn(
                name: "Mail",
                table: "SiteConfig");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "SiteConfig");

            migrationBuilder.DropColumn(
                name: "SmtpHost",
                table: "SiteConfig");

            migrationBuilder.DropColumn(
                name: "SmtpMail",
                table: "SiteConfig");

            migrationBuilder.DropColumn(
                name: "SmtpMailPass",
                table: "SiteConfig");

            migrationBuilder.DropColumn(
                name: "SmtpPort",
                table: "SiteConfig");

            migrationBuilder.DropColumn(
                name: "SmtpSSL",
                table: "SiteConfig");
        }
    }
}
