namespace EventFlow.Application.DTOs;

public class PaymentSummaryDto
{
    public int Last4 { get; set; }
    public string Brand { get; set; } = string.Empty;
    public int ExpMonth { get; set; }
    public int ExpYear { get; set; }
}
