﻿namespace EventFlow.Application.DTOs;

public class CartItemDto
{
    public Guid TicketId { get; set; }
    public string EventName { get; set; } = string.Empty;
    public Guid EventId { get; set; }
    public string TicketType { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
