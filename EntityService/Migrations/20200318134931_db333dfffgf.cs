using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityService.Migrations
{
    public partial class db333dfffgf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ServiceConfig",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ServiceConfig",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
