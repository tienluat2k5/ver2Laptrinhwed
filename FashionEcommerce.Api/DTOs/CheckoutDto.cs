using System.ComponentModel.DataAnnotations;

public class CheckoutDto
{
    public int UserId { get; set; }

    [Required]
    public string ShippingName { get; set; } = string.Empty;

    [Required]
    public string ShippingAddress { get; set; } = string.Empty;

    [Required]
    public string ShippingPhone { get; set; } = string.Empty;

    public string PaymentMethod { get; set; } = string.Empty;

}