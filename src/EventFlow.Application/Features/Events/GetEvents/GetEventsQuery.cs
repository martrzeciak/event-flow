using EventFlow.Application.Abstractions.CQRS;
using EventFlow.Application.Common;
using EventFlow.Application.DTOs;

namespace EventFlow.Application.Features.Events.GetEvents;

public class GetEventListsQuery : IQuery<PagedList<EventQueryDto>>
{
    public required EventParams EventParams { get; set; }
}
