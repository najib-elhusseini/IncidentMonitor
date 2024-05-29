using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IncidentMonitor.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanySite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanySiteId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSuperUser",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ReceivesNotifications",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CompanySites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyName = table.Column<string>(type: "TEXT", nullable: true),
                    ShiftStartHours = table.Column<int>(type: "INTEGER", nullable: false),
                    ShiftStartMinutes = table.Column<int>(type: "INTEGER", nullable: false),
                    ShiftEndHours = table.Column<int>(type: "INTEGER", nullable: false),
                    ShiftEndMinutes = table.Column<int>(type: "INTEGER", nullable: false),
                    EnableEmailNotifications = table.Column<bool>(type: "INTEGER", nullable: true),
                    EnableAlarmNotifications = table.Column<bool>(type: "INTEGER", nullable: true),
                    AlarmInterval = table.Column<int>(type: "INTEGER", nullable: true),
                    AlarmIntervalSeconds = table.Column<int>(type: "INTEGER", nullable: true),
                    RefreshInterval = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanySites", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanySiteId",
                table: "AspNetUsers",
                column: "CompanySiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CompanySites_CompanySiteId",
                table: "AspNetUsers",
                column: "CompanySiteId",
                principalTable: "CompanySites",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CompanySites_CompanySiteId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CompanySites");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CompanySiteId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CompanySiteId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsSuperUser",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ReceivesNotifications",
                table: "AspNetUsers");
        }
    }
}
