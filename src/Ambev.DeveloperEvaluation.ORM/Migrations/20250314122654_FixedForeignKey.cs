using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class FixedForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleItems_Sales_Id",
                table: "SaleItems");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_SaleId",
                table: "SaleItems",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItems_Sales_SaleId",
                table: "SaleItems",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleItems_Sales_SaleId",
                table: "SaleItems");

            migrationBuilder.DropIndex(
                name: "IX_SaleItems_SaleId",
                table: "SaleItems");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItems_Sales_Id",
                table: "SaleItems",
                column: "Id",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
