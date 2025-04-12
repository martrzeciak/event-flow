namespace EventFlow.Domain.Entities.OrderAggregate;

public class Order : BaseEntity
{
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public string BuyerEmail { get; set; } = default!;
    public PaymentSummary PaymentSummary { get; set; } = null!;
    public List<OrderItem> OrderItems { get; set; } = [];
    public decimal Subtotal { get; set; }
    public decimal Discount { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public required string PaymentIntentId { get; set; }

    public decimal GetTotal()
    {
        return Subtotal - Discount;
    }
}
