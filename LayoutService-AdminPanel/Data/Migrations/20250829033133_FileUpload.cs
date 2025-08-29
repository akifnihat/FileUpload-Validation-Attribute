using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LayoutService_AdminPanel.Migrations
{
    /// <inheritdoc />
    public partial class FileUpload : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Sliders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Sliders");
        }
    }
}
