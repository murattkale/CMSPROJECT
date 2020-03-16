using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DynamicSiteEntity.Migrations
{
    public partial class db345536356 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BodyScript",
                table: "ContentPage");

            migrationBuilder.DropColumn(
                name: "DefaultImage",
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

            migrationBuilder.AddColumn<string>(
                name: "ThumbImage",
                table: "ContentPage",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SiteConfig",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreaDate = table.Column<DateTime>(nullable: false),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    LoginCount = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    StartPage = table.Column<string>(nullable: false),
                    StartAction = table.Column<string>(nullable: false),
                    version = table.Column<string>(nullable: false),
                    Copyright = table.Column<string>(nullable: false),
                    layoutID = table.Column<string>(nullable: false),
                    layoutUrlBase = table.Column<string>(nullable: false),
                    layoutUrl = table.Column<string>(nullable: false),
                    Logo = table.Column<string>(nullable: false),
                    DefaultImage = table.Column<string>(nullable: true),
                    BaseUrl = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    JokerPass = table.Column<string>(nullable: false),
                    MetaKeywords = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    HeadScript = table.Column<string>(nullable: true),
                    HeadStyle = table.Column<string>(nullable: true),
                    BodyScript = table.Column<string>(nullable: true),
                    FooterScript = table.Column<string>(nullable: true),
                    FooterStyle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteConfig", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteConfig");

            migrationBuilder.DropColumn(
                name: "ThumbImage",
                table: "ContentPage");

            migrationBuilder.AddColumn<string>(
                name: "BodyScript",
                table: "ContentPage",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DefaultImage",
                table: "ContentPage",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FooterScript",
                table: "ContentPage",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FooterStyle",
                table: "ContentPage",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeadScript",
                table: "ContentPage",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeadStyle",
                table: "ContentPage",
                type: "text",
                nullable: true);
        }
    }
}
