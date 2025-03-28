using EventFlow.Application.Abstractions.CQRS;
using EventFlow.Application.Common;
using EventFlow.Application.DTOs;

namespace EventFlow.Application.Features.Events.Queries.GetEventList;

public class GetEventListQuery : IQuery<PagedList<EventQueryDto>>
{
    public required EventParams EventParams { get; set; }
}
