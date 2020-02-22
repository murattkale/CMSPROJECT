using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Migrations
{
    public partial class db1 : Migration
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
                name: "IX_Roles_ParentId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_StartPageId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "StartPageId",
                table: "Roles");

            migrationBuilder.AddColumn<int>(
                name: "fk_RolesId",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fk_ServiceConfigId",
                table: "Roles",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "CountryId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartPageId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ParentId",
                table: "Roles",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_StartPageId",
                table: "Roles",
                column: "StartPageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Roles",
                table: "Roles",
                column: "ParentId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_ServiceConfig",
                table: "Roles",
                column: "StartPageId",
                principalTable: "ServiceConfig",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
