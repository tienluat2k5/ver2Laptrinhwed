using System.Text.Json.Serialization;

namespace FashionEcommerce.Api.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? ParentId { get; set; }
        [JsonIgnore]
        public Category? Parent { get; set; }
    }
}