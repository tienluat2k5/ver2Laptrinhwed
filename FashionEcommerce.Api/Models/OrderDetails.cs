using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FashionEcommerce.Api.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        [JsonIgnore]
        public Order? Order { get; set; }

        public int ProductVariantId { get; set; }
        public ProductVariant? ProductVariant { get; set; }

        [Required]
        [StringLength(255)]
        public string Snapshot_ProductName { get; set; } = string.Empty;

        [StringLength(100)]
        public string Snapshot_Sku { get; set; } = string.Empty;

        [StringLength(500)]
        public string Snapshot_Thumbnail { get; set; } = string.Empty;

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
    }
}