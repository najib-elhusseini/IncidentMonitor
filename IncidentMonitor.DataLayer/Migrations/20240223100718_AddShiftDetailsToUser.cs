using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IncidentMonitor.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddShiftDetailsToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReceivesNotifications",
                table: "AspNetUsers",
                newName: "EnableEmailNotifications");

            migrationBuilder.AddColumn<int>(
                name: "ShiftEndHours",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShiftEndMinutes",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShiftStartHours",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShiftStartMinutes",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShiftEndHours",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ShiftEndMinutes",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ShiftStartHours",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ShiftStartMinutes",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "EnableEmailNotifications",
                table: "AspNetUsers",
                newName: "ReceivesNotifications");
        }
    }
}
