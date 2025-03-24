using EventFlow.Application.DTOs;
using EventFlow.Domain.Entities;
using Mapster;

namespace EventFlow.Application.MappingProfiles;

public class EventMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Event, EventQueryDto>()
            .Map(dest => dest.Tickets, src => src.Tickets.OrderBy(p => p.Price));
    }
}