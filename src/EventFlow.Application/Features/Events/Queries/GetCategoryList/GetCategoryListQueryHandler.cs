using EventFlow.Application.Abstractions.CQRS;
using EventFlow.Application.Common;
using EventFlow.Application.Common.Errors;
using EventFlow.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace EventFlow.Application.Features.Events.Queries.GetCategoryList;

public class GetCategoryListQueryHandler(AppDbContext context)
    : IQueryHandler<GetCategoryListQuery, List<string>>
{
    public async Task<Result<List<string>>> Handle(GetCategoryListQuery request, 
        CancellationToken cancellationToken)
    {
        var categories = await context.Events
            .AsNoTracking()
            .SelectMany(x => x.Categories)
            .Distinct()
            .OrderBy(x => x)
            .ToListAsync(cancellationToken);

        if (categories is null)
            return Result.Failure<List<string>>(EventError.CategoryNotFound);

        return Result.Success(categories);
    }
}
