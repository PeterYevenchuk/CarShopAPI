using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarPhotos_Cars_IdCar",
                table: "CarPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Cars_IdCar",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_IdUser",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "IdCar",
                table: "Orders",
                newName: "CarId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_IdUser",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_IdCar",
                table: "Orders",
                newName: "IX_Orders_CarId");

            migrationBuilder.RenameColumn(
                name: "IdCar",
                table: "CarPhotos",
                newName: "CarId");

            migrationBuilder.RenameIndex(
                name: "IX_CarPhotos_IdCar",
                table: "CarPhotos",
                newName: "IX_CarPhotos_CarId");

            migrationBuilder.AddColumn<Guid>(
                name: "AdditionalFunctionalityId",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "DateCreated",
                table: "Cars",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StandartColor",
                table: "Cars",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AdditionalFunctionality",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: false),
                    GPSNavigation = table.Column<bool>(type: "INTEGER", nullable: false),
                    ParkingSensors = table.Column<bool>(type: "INTEGER", nullable: false),
                    PremiumSoundSystem = table.Column<bool>(type: "INTEGER", nullable: false),
                    LeatherSeats = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalFunctionality", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AdditionalFunctionalityId",
                table: "Orders",
                column: "AdditionalFunctionalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarPhotos_Cars_CarId",
                table: "CarPhotos",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AdditionalFunctionality_AdditionalFunctionalityId",
                table: "Orders",
                column: "AdditionalFunctionalityId",
                principalTable: "AdditionalFunctionality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Cars_CarId",
                table: "Orders",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarPhotos_Cars_CarId",
                table: "CarPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AdditionalFunctionality_AdditionalFunctionalityId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Cars_CarId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "AdditionalFunctionality");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AdditionalFunctionalityId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AdditionalFunctionalityId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "StandartColor",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "Orders",
                newName: "IdCar");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                newName: "IX_Orders_IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CarId",
                table: "Orders",
                newName: "IX_Orders_IdCar");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "CarPhotos",
                newName: "IdCar");

            migrationBuilder.RenameIndex(
                name: "IX_CarPhotos_CarId",
                table: "CarPhotos",
                newName: "IX_CarPhotos_IdCar");

            migrationBuilder.AddForeignKey(
                name: "FK_CarPhotos_Cars_IdCar",
                table: "CarPhotos",
                column: "IdCar",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Cars_IdCar",
                table: "Orders",
                column: "IdCar",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_IdUser",
                table: "Orders",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
