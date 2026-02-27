namespace FashionEcommerce.Api.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public int PromotionId { get; set; }
        public int UserId { get; set; }
    }
}