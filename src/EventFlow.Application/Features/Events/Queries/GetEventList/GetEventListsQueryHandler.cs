using EventFlow.Application.Abstractions.CQRS;
using EventFlow.Application.Common;
using EventFlow.Application.DTOs;
using EventFlow.Persistence.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace EventFlow.Application.Features.Events.Queries.GetEventList;

public class GetEventListQueryHandler(AppDbContext context)
    : IQueryHandler<GetEventListQuery, PagedList<EventQueryDto>>
{
    public async Task<Result<PagedList<EventQueryDto>>> Handle(GetEventListQuery request,
        CancellationToken cancellationToken)
    {
        var query = context.Events
            .AsNoTracking()
            .ProjectToType<EventQueryDto>();

        if (!string.IsNullOrEmpty(request.EventParams.Search))
        {
            query = query.Where(x => x.Name
                .Contains(request.EventParams.Search));
        }

        if (!string.IsNullOrEmpty(request.EventParams.Categories))
        {
            var categories = request.EventParams.Categories
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToHashSet();

            query = query.Where(x => x.Categories.Any(c => categories.Contains(c)));
        }

        if (request.EventParams.DateFrom.HasValue)
        {
            query = query.Where(x => x.Date >= request.EventParams.DateFrom.Value);
        }

        if (request.EventParams.DateTo.HasValue)
        {
            query = query.Where(x => x.Date <= request.EventParams.DateTo.Value.AddDays(1));
        }

        query = request.EventParams.OrderBy switch
        {
            "date" => query.OrderBy(x => x.Date),
            "dateDesc" => query.OrderByDescending(x => x.Date),
            "name" => query.OrderBy(x => x.Name),
            _ => query.OrderBy(x => x.Date)
        };

        return Result.Success(await PagedList<EventQueryDto>
            .CreateAsync(query, request.EventParams.PageNumber, 
                request.EventParams.PageSize));
    }
}
