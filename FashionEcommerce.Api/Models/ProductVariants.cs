namespace FashionEcommerce.Api.Models
{
    public class ProductVariant
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? SKU { get; set; }
        public int Quantity { get; set; }
        public decimal PriceModifier { get; set; }
    }
}