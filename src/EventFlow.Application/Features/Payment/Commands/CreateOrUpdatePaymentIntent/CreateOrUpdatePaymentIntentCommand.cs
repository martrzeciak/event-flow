using EventFlow.Application.Abstractions.CQRS;
using EventFlow.Application.DTOs;

namespace EventFlow.Application.Features.Payment.Commands.CreateOrUpdatePaymentIntent;

public class CreateOrUpdatePaymentIntentCommand : ICommand<ShoppingCartDto>
{
    public required string CartId { get; set; }
}
