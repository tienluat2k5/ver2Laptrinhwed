namespace FashionEcommerce.Api.Models
{
    public class OrderStatusHistory
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Status { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}