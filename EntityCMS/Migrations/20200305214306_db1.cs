using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DynamicSiteEntity.Migrations
{
    public partial class db1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContentPage",
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
                    KurumId = table.Column<int>(nullable: true),
                    SubeId = table.Column<int>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ContentPageType = table.Column<int>(nullable: false),
                    IsHeaderMenu = table.Column<bool>(nullable: true),
                    IsFooterMenu = table.Column<bool>(nullable: true),
                    IsSideMenu = table.Column<bool>(nullable: true),
                    IsHamburgerMenu = table.Column<bool>(nullable: true),
                    ContentData = table.Column<string>(nullable: true),
                    ContentShort = table.Column<string>(nullable: true),
                    MetaKeywords = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    BannerText = table.Column<string>(nullable: true),
                    BannerImage = table.Column<string>(nullable: true),
                    DefaultImage = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    ButtonText1 = table.Column<string>(nullable: true),
                    ButtonText1Link = table.Column<string>(nullable: true),
                    ButtonText2 = table.Column<string>(nullable: true),
                    ButtonText2Link = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentPage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Formlar",
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
                    Ad = table.Column<string>(nullable: false),
                    Soyad = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    Adres = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    TownId = table.Column<int>(nullable: true),
                    Icerik = table.Column<string>(nullable: true),
                    FormType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
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
                    Types = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Guid = table.Column<string>(nullable: true),
                    Alt = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    data_class = table.Column<string>(nullable: true),
                    dataid = table.Column<int>(nullable: false),
                    ContentPageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_ContentPage_ContentPageId",
                        column: x => x.ContentPageId,
                        principalTable: "ContentPage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ContentPageId",
                table: "Documents",
                column: "ContentPageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Formlar");

            migrationBuilder.DropTable(
                name: "ContentPage");
        }
    }
}
