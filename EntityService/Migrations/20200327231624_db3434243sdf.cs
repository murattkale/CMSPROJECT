using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityService.Migrations
{
    public partial class db3434243sdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YakinlikDerecesiId",
                table: "VeliDetay");

            migrationBuilder.AddColumn<int>(
                name: "YakinlikDerecesi",
                table: "VeliDetay",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YakinlikDerecesi",
                table: "VeliDetay");

            migrationBuilder.AddColumn<int>(
                name: "YakinlikDerecesiId",
                table: "VeliDetay",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
