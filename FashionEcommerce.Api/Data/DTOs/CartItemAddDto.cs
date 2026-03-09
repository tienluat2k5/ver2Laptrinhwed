namespace FashionEcommerce.Api.DTOs
{
    public class CartItemAddDto
    {
        public int UserId { get; set; }
        public int ProductVariantId { get; set; }
        public int Quantity { get; set; }
    }
}