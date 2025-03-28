namespace EventFlow.Application.DTOs;

public class ShoppingCartDto
{
    public string Id { get; set; } = string.Empty;
    public List<CartItemDto> Items { get; set; } = [];
    public string? ClientSecret { get; set; }
    public string? PaymentIntentId { get; set; }
}
