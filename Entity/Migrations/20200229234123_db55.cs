using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Migrations
{
    public partial class db55 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "NeredenDuydunuz");

            migrationBuilder.AddColumn<string>(
                name: "Ad",
                table: "NeredenDuydunuz",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "OkulTip",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    Ad = table.Column<string>(nullable: false),
                    OkulTipId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OkulTip", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Okullar_OkulTipId",
                table: "Okullar",
                column: "OkulTipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Okullar_OkulTip",
                table: "Okullar",
                column: "OkulTipId",
                principalTable: "OkulTip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Okullar_OkulTip",
                table: "Okullar");

            migrationBuilder.DropTable(
                name: "OkulTip");

            migrationBuilder.DropIndex(
                name: "IX_Okullar_OkulTipId",
                table: "Okullar");

            migrationBuilder.DropColumn(
                name: "Ad",
                table: "NeredenDuydunuz");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "NeredenDuydunuz",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
