using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixTableNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "Notifications");

            migrationBuilder.AddColumn<string>(
                name: "MessageAccount",
                table: "Notifications",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MessageEmail",
                table: "Notifications",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageAccount",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "MessageEmail",
                table: "Notifications");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Notifications",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
