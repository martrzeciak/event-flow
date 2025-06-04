namespace EventFlow.Application.DTOs;

public class OrderItemQueryDto
{
    public Guid TicketId { get; set; }
    public string EventName { get; set; } = string.Empty;
    public string PictureUrl { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
