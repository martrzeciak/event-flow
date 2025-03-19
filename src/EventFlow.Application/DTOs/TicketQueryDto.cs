using EventFlow.Domain.Entities;

namespace EventFlow.Application.DTOs;

public class TicketQueryDto
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public string TicketType { get; set; } = string.Empty;
    public int TicketsAvailable { get; set; }
}
