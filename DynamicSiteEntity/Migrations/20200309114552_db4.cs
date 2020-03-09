using Microsoft.EntityFrameworkCore.Migrations;

namespace DynamicSiteEntity.Migrations
{
    public partial class db4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BodyScript",
                table: "ContentPage",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FooterScript",
                table: "ContentPage",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FooterStyle",
                table: "ContentPage",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeadScript",
                table: "ContentPage",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeadStyle",
                table: "ContentPage",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BodyScript",
                table: "ContentPage");

            migrationBuilder.DropColumn(
                name: "FooterScript",
                table: "ContentPage");

            migrationBuilder.DropColumn(
                name: "FooterStyle",
                table: "ContentPage");

            migrationBuilder.DropColumn(
                name: "HeadScript",
                table: "ContentPage");

            migrationBuilder.DropColumn(
                name: "HeadStyle",
                table: "ContentPage");
        }
    }
}
