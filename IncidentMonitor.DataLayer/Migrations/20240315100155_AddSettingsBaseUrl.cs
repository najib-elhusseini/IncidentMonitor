using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IncidentMonitor.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddSettingsBaseUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BaseUrl",
                table: "AssystSettings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseUrl",
                table: "AssystSettings");
        }
    }
}
