namespace FashionEcommerce.Api.Models
{
    public class UserAddress
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public bool IsDefault { get; set; }
    }
}