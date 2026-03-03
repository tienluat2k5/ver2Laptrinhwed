using System.ComponentModel.DataAnnotations.Schema;

namespace FashionEcommerce.Api.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountValue { get; set; }
    }
}