using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Order
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string OrderCode { get; set; } = string.Empty;

    public int UserId { get; set; }

    public DateTime OrderDate { get; set; }

    [Required]
    [StringLength(100)]
    public string ShippingName { get; set; } = string.Empty;

    [Required]
    [StringLength(255)]
    public string ShippingAddress { get; set; } = string.Empty;

    [Required]
    [StringLength(20)]
    public string ShippingPhone { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal DiscountAmount { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal FinalAmount { get; set; }

    [StringLength(50)]
    public string PaymentMethod { get; set; } = string.Empty;

    [StringLength(50)]
    public string PaymentStatus { get; set; } = string.Empty;

    [StringLength(50)]
    public string Status { get; set; } = string.Empty;

    // Navigation
    public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}