using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionEcommerce.Api.Models
{
   public class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public int CategoryId { get; set; }

    [JsonIgnore]
    public Category? Category { get; set; }
}
}