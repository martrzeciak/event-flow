using EventFlow.Application.Common;

namespace EventFlow.Application.Features.Events.GetEvents;

public class EventParams : PagingParams
{
    public required string OrderBy { get; set; }
}
