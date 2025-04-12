using EventFlow.Application.Abstractions.CQRS;
using EventFlow.Application.Common;
using EventFlow.Application.DTOs;

namespace EventFlow.Application.Features.Orders.Queries.GetOrderListForUser;

public class GetOrderListForUserQuery : IQuery<PagedList<OrderQueryDto>>
{
    public required PagingParams PagingParams { get; set; }
}
