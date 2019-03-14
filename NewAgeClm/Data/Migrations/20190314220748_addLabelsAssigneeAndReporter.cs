using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewAgeClm.Data.Migrations
{
    public partial class addLabelsAssigneeAndReporter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Assignee",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LabelId",
                table: "Projects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Reporter",
                table: "Projects",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Labels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_LabelId",
                table: "Projects",
                column: "LabelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Labels_LabelId",
                table: "Projects",
                column: "LabelId",
                principalTable: "Labels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Labels_LabelId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Labels");

            migrationBuilder.DropIndex(
                name: "IX_Projects_LabelId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Assignee",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "LabelId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Reporter",
                table: "Projects");
        }
    }
}
