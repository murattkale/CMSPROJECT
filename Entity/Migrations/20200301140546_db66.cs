using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Migrations
{
    public partial class db66 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OgrenciSozlesme_SozlesmeTur",
                table: "OgrenciSozlesme");

            migrationBuilder.DropIndex(
                name: "IX_OgrenciSozlesme_SozlesmeTuruId",
                table: "OgrenciSozlesme");

            migrationBuilder.DropColumn(
                name: "SozlesmeTuruId",
                table: "OgrenciSozlesme");

            migrationBuilder.AddColumn<int>(
                name: "SozlesmeTurId",
                table: "OgrenciSozlesme",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VeliDetay_OgrenciDetayId",
                table: "VeliDetay",
                column: "OgrenciDetayId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciSozlesme_SozlesmeTurId",
                table: "OgrenciSozlesme",
                column: "SozlesmeTurId");

            migrationBuilder.AddForeignKey(
                name: "FK_OgrenciSozlesme_SozlesmeTur",
                table: "OgrenciSozlesme",
                column: "SozlesmeTurId",
                principalTable: "SozlesmeTur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VeliDetay_OgrenciDetay",
                table: "VeliDetay",
                column: "OgrenciDetayId",
                principalTable: "OgrenciDetay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OgrenciSozlesme_SozlesmeTur",
                table: "OgrenciSozlesme");

            migrationBuilder.DropForeignKey(
                name: "FK_VeliDetay_OgrenciDetay",
                table: "VeliDetay");

            migrationBuilder.DropIndex(
                name: "IX_VeliDetay_OgrenciDetayId",
                table: "VeliDetay");

            migrationBuilder.DropIndex(
                name: "IX_OgrenciSozlesme_SozlesmeTurId",
                table: "OgrenciSozlesme");

            migrationBuilder.DropColumn(
                name: "SozlesmeTurId",
                table: "OgrenciSozlesme");

            migrationBuilder.AddColumn<int>(
                name: "SozlesmeTuruId",
                table: "OgrenciSozlesme",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciSozlesme_SozlesmeTuruId",
                table: "OgrenciSozlesme",
                column: "SozlesmeTuruId");

            migrationBuilder.AddForeignKey(
                name: "FK_OgrenciSozlesme_SozlesmeTur",
                table: "OgrenciSozlesme",
                column: "SozlesmeTuruId",
                principalTable: "SozlesmeTur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
