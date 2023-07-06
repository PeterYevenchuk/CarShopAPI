using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTableWithPriceFunc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "AdditionalFunctionalities",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "AdditionalFunctionalityPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ColorPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    GPSNavigationPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    ParkingSensorsPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    PremiumSoundSystemPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    LeatherSeatsPrice = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalFunctionalityPrices", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalFunctionalityPrices");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "AdditionalFunctionalities",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
