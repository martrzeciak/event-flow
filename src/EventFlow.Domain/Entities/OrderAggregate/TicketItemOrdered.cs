namespace EventFlow.Domain.Entities.OrderAggregate;

public class TicketItemOrdered
{
    public Guid TicketId { get; set; }
    public string EventName { get; set; } = default!;
}
