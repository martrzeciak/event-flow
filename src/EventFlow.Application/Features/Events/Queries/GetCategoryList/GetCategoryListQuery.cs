using EventFlow.Application.Abstractions.CQRS;

namespace EventFlow.Application.Features.Events.Queries.GetCategoryList;

public class GetCategoryListQuery : IQuery<List<string>>
{
}
