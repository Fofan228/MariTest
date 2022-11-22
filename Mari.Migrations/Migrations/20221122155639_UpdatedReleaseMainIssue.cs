using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mari.Migrations.Migrations
{
    public partial class UpdatedReleaseMainIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "main_issue_link",
                table: "releases");

            migrationBuilder.RenameColumn(
                name: "main_issue_title",
                table: "releases",
                newName: "main_issue");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "main_issue",
                table: "releases",
                newName: "main_issue_title");

            migrationBuilder.AddColumn<string>(
                name: "main_issue_link",
                table: "releases",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
