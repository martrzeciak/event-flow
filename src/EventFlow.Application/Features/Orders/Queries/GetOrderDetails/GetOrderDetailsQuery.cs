using EventFlow.Application.Abstractions.CQRS;
using EventFlow.Application.DTOs;

namespace EventFlow.Application.Features.Orders.Queries.GetOrderDetails;

public class GetOrderDetailsQuery : IQuery<OrderQueryDto>
{
    public required Guid Id { get; set; }
}

