using Microsoft.EntityFrameworkCore.Migrations;

namespace NewAgeClm.Data.Migrations
{
    public partial class AddPriorityToProjetcts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriorityId",
                table: "Projects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PriorityId",
                table: "Projects",
                column: "PriorityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Priorities_PriorityId",
                table: "Projects",
                column: "PriorityId",
                principalTable: "Priorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Priorities_PriorityId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_PriorityId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "PriorityId",
                table: "Projects");
        }
    }
}
