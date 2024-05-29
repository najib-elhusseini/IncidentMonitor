using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IncidentMonitor.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddExternalIdToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExternalId",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "AspNetUsers");
        }
    }
}
