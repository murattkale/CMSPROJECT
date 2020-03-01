using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Migrations
{
    public partial class db77 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "Yayin",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "VeliDetay",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "UserRoles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "Town",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "Sube",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "SozlesmeTur",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "Sozlesme",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "SinifOgrenci",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "Sinif",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "Sezon",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "Servis",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "ServiceConfigAuth",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "ServiceConfig",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "Seans",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "Permissions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "ParaBirimi",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "OkulTip",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "Okullar",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "OgrenciSozlesmeYayin",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "OgrenciSozlesmeOdemeTablosu",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "OgrenciSozlesmeKiyafet",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "OgrenciSozlesme",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "OgrenciDetay",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "OdemeTip",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "OdemeDetay",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "NeredenDuydunuz",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "Kurum",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "KiyafetTur",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "Kiyafet",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "Kasa",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "HesapTip",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "Hesap",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "Formlar",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "Documents",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "Derslik",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "DersGrup",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "DersBrans",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "Ders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "ContentPage",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "City",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "Brans",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "Banka",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "Yayin");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "VeliDetay");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "Town");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "Sube");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "SozlesmeTur");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "Sozlesme");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "SinifOgrenci");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "Sinif");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "Sezon");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "Servis");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "ServiceConfigAuth");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "ServiceConfig");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "Seans");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "ParaBirimi");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "OkulTip");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "Okullar");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "OgrenciSozlesmeYayin");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "OgrenciSozlesmeOdemeTablosu");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "OgrenciSozlesmeKiyafet");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "OgrenciSozlesme");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "OgrenciDetay");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "OdemeTip");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "OdemeDetay");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "NeredenDuydunuz");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "Kurum");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "KiyafetTur");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "Kiyafet");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "Kasa");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "HesapTip");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "Hesap");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "Formlar");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "Derslik");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "DersGrup");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "DersBrans");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "Ders");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "ContentPage");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "City");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "Brans");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "Banka");
        }
    }
}
