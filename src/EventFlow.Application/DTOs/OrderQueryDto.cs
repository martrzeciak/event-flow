namespace EventFlow.Application.DTOs;

public class OrderQueryDto
{
    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string BuyerEmail { get; set; } = string.Empty;
    public int Last4 { get; set; }
    public string Brand { get; set; } = string.Empty;
    public int ExpMonth { get; set; }
    public int ExpYear { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Discount { get; set; }
    public string Status { get; set; } = string.Empty;
    public string PaymentIntentId { get; set; } = string.Empty;
}
