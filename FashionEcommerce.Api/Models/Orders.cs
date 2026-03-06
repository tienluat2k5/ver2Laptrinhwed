namespace FashionEcommerce.Api.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Status { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}