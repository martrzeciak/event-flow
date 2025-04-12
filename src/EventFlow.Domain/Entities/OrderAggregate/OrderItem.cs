namespace EventFlow.Domain.Entities.OrderAggregate;

public class OrderItem : BaseEntity
{
    public TicketItemOrdered ItemOrdered { get; set; } = default!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
