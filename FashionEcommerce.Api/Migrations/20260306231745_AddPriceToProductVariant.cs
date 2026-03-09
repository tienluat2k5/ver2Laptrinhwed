using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FashionEcommerce.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceToProductVariant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sku",
                table: "ProductVariants",
                newName: "SKU");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ProductVariants",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductVariants");

            migrationBuilder.RenameColumn(
                name: "SKU",
                table: "ProductVariants",
                newName: "Sku");
        }
    }
}