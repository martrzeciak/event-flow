using EventFlow.Application.Abstractions.CQRS;
using EventFlow.Application.DTOs;

namespace EventFlow.Application.Features.Events.Queries.GetEventDetails;

public class GetEventDetailsQuery : IQuery<EventQueryDto>
{
    public required Guid Id { get; set; }
}
