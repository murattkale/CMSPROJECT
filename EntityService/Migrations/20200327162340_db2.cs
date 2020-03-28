using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityService.Migrations
{
    public partial class db2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AileMedeniDurum",
                table: "OgrenciDetay",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AileMedeniDurum",
                table: "OgrenciDetay");
        }
    }
}
