namespace EventFlow.Domain.Entities;

public class CartItem
{
    public Guid TicketId { get; set; }
    public string EventName { get; set; } = default!;
    public Guid EventId { get; set; }
    public string TicketType { get; set; } = default!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
