using EventFlow.Application.Abstractions.CQRS;
using EventFlow.Application.Common;
using EventFlow.Application.DTOs;
using EventFlow.Domain.Entities;

namespace EventFlow.Application.Features.Events.GetEvents;

public class GetEventListsQuery : IQuery<PagedList<EventQueryDto>>
{
    public required PagingParams Params { get; set; }
}
