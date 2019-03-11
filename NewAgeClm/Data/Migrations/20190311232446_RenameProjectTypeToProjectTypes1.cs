using Microsoft.EntityFrameworkCore.Migrations;

namespace NewAgeClm.Data.Migrations
{
    public partial class RenameProjectTypeToProjectTypes1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectType_ProjectTypeId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectType",
                table: "ProjectType");

            migrationBuilder.RenameTable(
                name: "ProjectType",
                newName: "ProjectTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTypes",
                table: "ProjectTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectTypes_ProjectTypeId",
                table: "Projects",
                column: "ProjectTypeId",
                principalTable: "ProjectTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectTypes_ProjectTypeId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTypes",
                table: "ProjectTypes");

            migrationBuilder.RenameTable(
                name: "ProjectTypes",
                newName: "ProjectType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectType",
                table: "ProjectType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectType_ProjectTypeId",
                table: "Projects",
                column: "ProjectTypeId",
                principalTable: "ProjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
