using System.Text.Json.Serialization;

namespace FashionEcommerce.Api.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProductVariantId { get; set; }

        public int Quantity { get; set; }

        [JsonIgnore]
        public ProductVariant? ProductVariant { get; set; }
    }
}