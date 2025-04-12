using EventFlow.Application.Abstractions.CQRS;
using EventFlow.Application.Common;
using EventFlow.Application.Common.Errors;
using EventFlow.Application.DTOs;
using EventFlow.Domain.Interfaces;
using EventFlow.Persistence.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace EventFlow.Application.Features.Orders.Queries.GetOrderListForUser;

public class GetOrderListForUserQueryHandler(AppDbContext context, IUserService userService)
    : IQueryHandler<GetOrderListForUserQuery, PagedList<OrderQueryDto>>
{
    public async Task<Result<PagedList<OrderQueryDto>>> Handle(GetOrderListForUserQuery request, 
        CancellationToken cancellationToken)
    {
        var userEmail = userService.GetUserEmail();

        if (userEmail is null)
            return Result.Failure<PagedList<OrderQueryDto>>(UserError.NotLoggedIn);

        var query = context.Orders
            .AsNoTracking()
            .Where(x => x.BuyerEmail == userEmail)
            .OrderByDescending(x => x.OrderDate)
            .ProjectToType<OrderQueryDto>();

        return Result.Success(await PagedList<OrderQueryDto>
            .CreateAsync(query, request.PagingParams.PageNumber,
                request.PagingParams.PageSize));
    }
}
