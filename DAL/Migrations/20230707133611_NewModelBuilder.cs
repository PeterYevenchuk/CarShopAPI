using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class NewModelBuilder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalFunctionalityPrices_Cars_CarId",
                table: "AdditionalFunctionalityPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_CarPhotos_Cars_CarId",
                table: "CarPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AdditionalFunctionalities_AdditionalFunctionalityId",
                table: "Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalFunctionalityPrices_Cars_CarId",
                table: "AdditionalFunctionalityPrices",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarPhotos_Cars_CarId",
                table: "CarPhotos",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AdditionalFunctionalities_AdditionalFunctionalityId",
                table: "Orders",
                column: "AdditionalFunctionalityId",
                principalTable: "AdditionalFunctionalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalFunctionalityPrices_Cars_CarId",
                table: "AdditionalFunctionalityPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_CarPhotos_Cars_CarId",
                table: "CarPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AdditionalFunctionalities_AdditionalFunctionalityId",
                table: "Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalFunctionalityPrices_Cars_CarId",
                table: "AdditionalFunctionalityPrices",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_CarPhotos_Cars_CarId",
                table: "CarPhotos",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AdditionalFunctionalities_AdditionalFunctionalityId",
                table: "Orders",
                column: "AdditionalFunctionalityId",
                principalTable: "AdditionalFunctionalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
