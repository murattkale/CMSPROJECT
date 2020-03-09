using Microsoft.EntityFrameworkCore.Migrations;

namespace DynamicSiteEntity.Migrations
{
    public partial class db6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Formlar");

            migrationBuilder.DropColumn(
                name: "TownId",
                table: "Formlar");

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Formlar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Soyad",
                table: "Formlar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Formlar",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Soyad",
                table: "Formlar",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Formlar",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TownId",
                table: "Formlar",
                type: "integer",
                nullable: true);
        }
    }
}
