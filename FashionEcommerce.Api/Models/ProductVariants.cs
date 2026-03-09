using System.Text.Json.Serialization;

namespace FashionEcommerce.Api.Models
{
    public class ProductVariant
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        [JsonIgnore]   // ⭐ QUAN TRỌNG
        public Product? Product { get; set; }

        public int ColorId { get; set; }

        public int SizeId { get; set; }

        public string? SKU { get; set; }

        public int Quantity { get; set; }

        public decimal PriceModifier { get; set; }

        public decimal Price { get; set; }

        public string? Name { get; set; }
    }
}