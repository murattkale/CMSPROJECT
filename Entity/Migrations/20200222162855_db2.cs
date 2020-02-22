using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Migrations
{
    public partial class db2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Roles",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_ServiceConfig",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_fk_RolesId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_fk_ServiceConfigId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "fk_RolesId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "fk_ServiceConfigId",
                table: "Roles");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceConfigId",
                table: "Roles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleId",
                table: "Roles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ServiceConfigId",
                table: "Roles",
                column: "ServiceConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Roles",
                table: "Roles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_ServiceConfig",
                table: "Roles",
                column: "ServiceConfigId",
                principalTable: "ServiceConfig",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Roles",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_ServiceConfig",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_RoleId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_ServiceConfigId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ServiceConfigId",
                table: "Roles");

            migrationBuilder.AddColumn<int>(
                name: "fk_RolesId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fk_ServiceConfigId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_fk_RolesId",
                table: "Roles",
                column: "fk_RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_fk_ServiceConfigId",
                table: "Roles",
                column: "fk_ServiceConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Roles",
                table: "Roles",
                column: "fk_RolesId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_ServiceConfig",
                table: "Roles",
                column: "fk_ServiceConfigId",
                principalTable: "ServiceConfig",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
