using EventFlow.Application.DTOs;
using EventFlow.Domain.Entities;
using Mapster;

namespace EventFlow.Application.MappingProfiles;

public class EventMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Event, EventQueryDto>()
            .Map(dest => dest.StandardTicketsAvailable, src => src.Tickets.Where(t => t.TicketType == TicketType.Standard)
                    .Select(t => t.TicketsAvailable)
                    .FirstOrDefault())
            .Map(dest => dest.VipTicketsAvailable, src => src.Tickets.Where(t => t.TicketType == TicketType.VIP)
                    .Select(t => t.TicketsAvailable)
                    .FirstOrDefault());
    }
}
