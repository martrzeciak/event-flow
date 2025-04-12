using EventFlow.Application.Abstractions.CQRS;
using EventFlow.Application.DTOs;

namespace EventFlow.Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderCommand : ICommand<OrderQueryDto>
{
    public required CreateOrderDto CreateOrderDto { get; set; }
}
