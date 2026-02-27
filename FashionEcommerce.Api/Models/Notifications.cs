namespace FashionEcommerce.Api.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Content { get; set; }
        public bool IsRead { get; set; }
    }
}