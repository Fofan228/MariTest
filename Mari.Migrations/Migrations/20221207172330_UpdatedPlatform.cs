using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mari.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPlatform : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "ak_platform_name",
                table: "platform");

            migrationBuilder.CreateIndex(
                name: "ix_platform_name",
                table: "platform",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_platform_name",
                table: "platform");

            migrationBuilder.AddUniqueConstraint(
                name: "ak_platform_name",
                table: "platform",
                column: "name");
        }
    }
}
