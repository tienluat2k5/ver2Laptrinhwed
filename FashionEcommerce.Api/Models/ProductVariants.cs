using System.ComponentModel.DataAnnotations.Schema;

namespace FashionEcommerce.Api.Models
{
    public class ProductVariant
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public string? SKU { get; set; }
        public int Quantity { get; set; }
       [Column(TypeName = "decimal(18,2)")]
        public decimal PriceModifier { get; set; }
    }
}