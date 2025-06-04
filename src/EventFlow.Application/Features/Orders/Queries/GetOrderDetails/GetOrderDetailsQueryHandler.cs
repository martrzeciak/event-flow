using EventFlow.Application.Abstractions.CQRS;
using EventFlow.Application.Common;
using EventFlow.Application.Common.Errors;
using EventFlow.Application.DTOs;
using EventFlow.Domain.Interfaces;
using EventFlow.Persistence.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace EventFlow.Application.Features.Orders.Queries.GetOrderDetails;

public class GetOrderDetailsQueryHandler(AppDbContext context, IUserService userService)
    : IQueryHandler<GetOrderDetailsQuery, OrderQueryDto>
{
    public async Task<Result<OrderQueryDto>> Handle(GetOrderDetailsQuery request, 
        CancellationToken cancellationToken)
    {
        var userEmail = userService.GetUserEmail();

        if (userEmail is null)
            return Result.Failure<OrderQueryDto>(UserError.NotLoggedIn);

        var query = await context.Orders
            .Where(x => x.BuyerEmail == userEmail)
            .Where(x => x.Id == request.Id)
            .ProjectToType<OrderQueryDto>()
            .FirstOrDefaultAsync(cancellationToken);

        if (query is null)
            return Result.Failure<OrderQueryDto>(OrderError.OrderNotFound);

        return Result.Success(query);
    }
}

