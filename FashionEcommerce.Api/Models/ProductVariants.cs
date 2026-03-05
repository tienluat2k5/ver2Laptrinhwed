public class ProductVariant
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int ColorId { get; set; }

    public int SizeId { get; set; }

    public string? Sku { get; set; }

    public int Quantity { get; set; }

    public decimal PriceModifier { get; set; }
}