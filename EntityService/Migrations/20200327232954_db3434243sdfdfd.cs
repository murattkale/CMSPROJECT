using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityService.Migrations
{
    public partial class db3434243sdfdfd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ad",
                table: "VeliDetay",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EvAdres",
                table: "VeliDetay",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsAdres",
                table: "VeliDetay",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "VeliDetay",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Not",
                table: "VeliDetay",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Soyad",
                table: "VeliDetay",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tc",
                table: "VeliDetay",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "VeliDetay",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ad",
                table: "VeliDetay");

            migrationBuilder.DropColumn(
                name: "EvAdres",
                table: "VeliDetay");

            migrationBuilder.DropColumn(
                name: "IsAdres",
                table: "VeliDetay");

            migrationBuilder.DropColumn(
                name: "Mail",
                table: "VeliDetay");

            migrationBuilder.DropColumn(
                name: "Not",
                table: "VeliDetay");

            migrationBuilder.DropColumn(
                name: "Soyad",
                table: "VeliDetay");

            migrationBuilder.DropColumn(
                name: "Tc",
                table: "VeliDetay");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "VeliDetay");
        }
    }
}
