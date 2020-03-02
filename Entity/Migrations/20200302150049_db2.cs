using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Migrations
{
    public partial class db2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_ServiceConfig",
                table: "Role");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_ServiceConfig_ServiceConfigId",
                table: "Role",
                column: "ServiceConfigId",
                principalTable: "ServiceConfig",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_ServiceConfig_ServiceConfigId",
                table: "Role");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_ServiceConfig",
                table: "Role",
                column: "ServiceConfigId",
                principalTable: "ServiceConfig",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
