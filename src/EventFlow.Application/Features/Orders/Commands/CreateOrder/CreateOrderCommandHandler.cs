using EventFlow.Application.Abstractions.CQRS;
using EventFlow.Application.Common;
using EventFlow.Application.Common.Errors;
using EventFlow.Application.DTOs;
using EventFlow.Domain.Entities.OrderAggregate;
using EventFlow.Domain.Interfaces;
using EventFlow.Persistence.Data;
using Mapster;

namespace EventFlow.Application.Features.Orders.Commands.CreateOrder;

internal class CreateOrderCommandHandler(AppDbContext context, 
    IUserService userService, ICartService cartService)
    : ICommandHandler<CreateOrderCommand, OrderQueryDto>
{
    public async Task<Result<OrderQueryDto>> Handle(CreateOrderCommand request, 
        CancellationToken cancellationToken)
    {
        var userEmail = userService.GetUserEmail();

        if (userEmail is null)
            return Result.Failure<OrderQueryDto>(UserError.NotLoggedIn);

        var cart = await cartService.GetCartAsync(request.CreateOrderDto.CartId);

        if (cart is null)
            return Result.Failure<OrderQueryDto>(CartError.NotFound);

        if (cart.PaymentIntentId is null)
            return Result.Failure<OrderQueryDto>(OrderError.PaymentIntentNotFound);

        var orderItems = new List<OrderItem>();

        foreach (var item in cart.Items)
        {
            var ticket = await context.Ticket.FindAsync([item.TicketId], cancellationToken);

            if (ticket is null)
                return Result.Failure<OrderQueryDto>(OrderError.OrderProblem);

            var itemOrdered = new TicketItemOrdered
            {
                TicketId = item.TicketId,
                EventName = item.EventName,
            };

            var orderItem = new OrderItem
            {
                ItemOrdered = itemOrdered,
                Price = item.Price,
                Quantity = item.Quantity
            };

            orderItems.Add(orderItem);
        }

        var order = new Order
        {
            OrderItems = orderItems,
            Subtotal = orderItems.Sum(x => x.Price * x.Quantity),
            Discount = request.CreateOrderDto.Discount,
            PaymentSummary = request.CreateOrderDto.PaymentSummary,
            PaymentIntentId = cart.PaymentIntentId,
            BuyerEmail = userEmail
        };

        order.Status = OrderStatus.PaymentReceived;

        context.Add(order);

        var result = await context.SaveChangesAsync() > 0;

        return result
            ? Result.Success(order.Adapt<OrderQueryDto>())
            : Result.Failure<OrderQueryDto>(OrderError.CreateFailed);
    }
}
