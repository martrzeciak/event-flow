namespace EventFlow.Application.DTOs;

public class OrderQueryDto
{
    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string BuyerEmail { get; set; } = string.Empty;
    public required PaymentSummaryDto PaymentSummary { get; set; }
    public required List<OrderItemQueryDto> OrderItems { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Total { get; set; }
    public required string Status { get; set; }
    public required string PaymentIntentId { get; set; }
}
