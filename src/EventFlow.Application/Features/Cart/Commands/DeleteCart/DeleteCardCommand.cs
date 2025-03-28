using EventFlow.Application.Abstractions.CQRS;

namespace EventFlow.Application.Features.Cart.Commands.DeleteCart;

public class DeleteCardCommand : ICommand
{
    public required string Id { get; set; }
}
