namespace EventFlow.Domain.Entities;

public class ShoppingCart
{
    public string Id { get; set; } = default!;
    public List<CartItem> Items { get; set; } = [];
    public string? ClientSecret { get; set; }
    public string? PaymentIntentId { get; set; }
}
