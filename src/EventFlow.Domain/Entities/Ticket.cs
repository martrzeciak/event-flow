namespace EventFlow.Domain.Entities;

public class Ticket : BaseEntity
{
    public decimal Price { get; set; }
    public TicketType TicketType { get; set; }
    public int TicketsAvailable { get; set; }

    public Guid EventId { get; set; }
    public Event Event { get; set; } = default!;
}