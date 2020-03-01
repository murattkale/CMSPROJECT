using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Migrations
{
    public partial class db2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OgrenciId",
                table: "OgrenciDetay",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciDetay_OgrenciId",
                table: "OgrenciDetay",
                column: "OgrenciId");

            migrationBuilder.AddForeignKey(
                name: "FK_OgrenciDetay_Ogrenci",
                table: "OgrenciDetay",
                column: "OgrenciId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OgrenciDetay_Ogrenci",
                table: "OgrenciDetay");

            migrationBuilder.DropIndex(
                name: "IX_OgrenciDetay_OgrenciId",
                table: "OgrenciDetay");

            migrationBuilder.DropColumn(
                name: "OgrenciId",
                table: "OgrenciDetay");
        }
    }
}
