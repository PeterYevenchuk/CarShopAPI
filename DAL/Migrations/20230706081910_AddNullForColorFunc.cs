using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddNullForColorFunc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AdditionalFunctionality_AdditionalFunctionalityId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdditionalFunctionality",
                table: "AdditionalFunctionality");

            migrationBuilder.RenameTable(
                name: "AdditionalFunctionality",
                newName: "AdditionalFunctionalities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdditionalFunctionalities",
                table: "AdditionalFunctionalities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AdditionalFunctionalities_AdditionalFunctionalityId",
                table: "Orders",
                column: "AdditionalFunctionalityId",
                principalTable: "AdditionalFunctionalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AdditionalFunctionalities_AdditionalFunctionalityId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdditionalFunctionalities",
                table: "AdditionalFunctionalities");

            migrationBuilder.RenameTable(
                name: "AdditionalFunctionalities",
                newName: "AdditionalFunctionality");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdditionalFunctionality",
                table: "AdditionalFunctionality",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AdditionalFunctionality_AdditionalFunctionalityId",
                table: "Orders",
                column: "AdditionalFunctionalityId",
                principalTable: "AdditionalFunctionality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
