using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DynamicSiteEntity.Migrations
{
    public partial class db34454dff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LangId",
                table: "ContentPage",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Lang",
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
                    Name = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lang", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContentPage_LangId",
                table: "ContentPage",
                column: "LangId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentPage_Lang_LangId",
                table: "ContentPage",
                column: "LangId",
                principalTable: "Lang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentPage_Lang_LangId",
                table: "ContentPage");

            migrationBuilder.DropTable(
                name: "Lang");

            migrationBuilder.DropIndex(
                name: "IX_ContentPage_LangId",
                table: "ContentPage");

            migrationBuilder.DropColumn(
                name: "LangId",
                table: "ContentPage");
        }
    }
}
