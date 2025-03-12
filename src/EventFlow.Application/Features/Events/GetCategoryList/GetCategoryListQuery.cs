using EventFlow.Application.Abstractions.CQRS;

namespace EventFlow.Application.Features.Events.GetCategoryList;

public class GetCategoryListQuery : IQuery<List<string>>
{
}
