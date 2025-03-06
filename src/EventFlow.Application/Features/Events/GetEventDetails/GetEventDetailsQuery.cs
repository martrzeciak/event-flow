using EventFlow.Application.Abstractions.CQRS;
using EventFlow.Application.DTOs;

namespace EventFlow.Application.Features.Events.GetEventDetails;

public class GetEventDetailsQuery : IQuery<EventQueryDto>
{
    public required Guid Id { get; set; }
}
