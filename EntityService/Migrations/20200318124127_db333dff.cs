using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityService.Migrations
{
    public partial class db333dff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GelirGiderTipi",
                table: "HesapTip",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GelirGiderTipi",
                table: "HesapTip",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
