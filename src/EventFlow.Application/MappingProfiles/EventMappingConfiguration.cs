using EventFlow.Application.DTOs;
using EventFlow.Domain.Entities;
using EventFlow.Domain.Entities.OrderAggregate;
using Mapster;

namespace EventFlow.Application.MappingProfiles;

public class EventMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Event, EventQueryDto>()
            .Map(dest => dest.Tickets, src => src.Tickets.OrderBy(p => p.Price));

        config.NewConfig<Order, OrderQueryDto>()
            .Map(dest => dest.PaymentSummary, src => src.PaymentSummary)
            .Map(dest => dest.OrderItems, src => src.OrderItems)
            .Map(dest => dest.Total, src => src.Subtotal - src.Discount);

        config.NewConfig<PaymentSummary, PaymentSummaryDto>();
        config.NewConfig<OrderItem, OrderItemQueryDto>()
            .Map(dest => dest.TicketId, src => src.ItemOrdered.TicketId)
            .Map(dest => dest.EventName, src => src.ItemOrdered.EventName);
    }
}
