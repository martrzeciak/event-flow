using EventFlow.Application.Abstractions.CQRS;
using EventFlow.Application.Common;
using EventFlow.Application.DTOs;
using EventFlow.Persistence.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace EventFlow.Application.Features.Events.GetEvents;

public class GetEventListQueryHandler(AppDbContext context)
    : IQueryHandler<GetEventListsQuery, PagedList<EventQueryDto>>
{
    public async Task<Result<PagedList<EventQueryDto>>> Handle(GetEventListsQuery request,
        CancellationToken cancellationToken)
    {
        var query = context.Events.ProjectToType<EventQueryDto>();

        return Result.Success(await PagedList<EventQueryDto>
            .CreateAsync(query, request.Params.PageNumber, request.Params.PageSize));
    }
}