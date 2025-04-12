using EventFlow.Domain.Entities.OrderAggregate;
using System.ComponentModel.DataAnnotations;

namespace EventFlow.Application.DTOs;

public class CreateOrderDto
{
    [Required]
    public string CartId { get; set; } = string.Empty;

    [Required]
    public required PaymentSummary PaymentSummary { get; set; }
    public decimal Discount { get; set; }
}
