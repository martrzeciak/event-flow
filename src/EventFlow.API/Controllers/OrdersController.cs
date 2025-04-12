using EventFlow.Application.Common;
using EventFlow.Application.DTOs;
using EventFlow.Application.Features.Orders.Commands.CreateOrder;
using EventFlow.Application.Features.Orders.Queries.GetOrderDetails;
using EventFlow.Application.Features.Orders.Queries.GetOrderListForUser;
using Microsoft.AspNetCore.Mvc;

namespace EventFlow.API.Controllers;

public class OrdersController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<OrderQueryDto>>> GetOrdersForUser(PagingParams pagingParams)
    {
        return HandlePagedResult(await Mediator.Send(new GetOrderListForUserQuery { PagingParams = pagingParams }));
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<OrderQueryDto>> GetOrderDetails(Guid id)
    {
        return HandleResult(await Mediator.Send(new GetOrderDetailsQuery { Id = id }));
    }

    [HttpPost]
    public async Task<ActionResult<OrderQueryDto>> CreateOrder(CreateOrderDto createOrderDto)
    {
        return HandleResult(await Mediator.Send(new CreateOrderCommand { CreateOrderDto = createOrderDto }));
    }
}
