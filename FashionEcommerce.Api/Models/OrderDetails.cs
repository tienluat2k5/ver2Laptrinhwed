namespace FashionEcommerce.Api.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductVariantId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public ProductVariant ProductVariant { get; set; }
    }
}