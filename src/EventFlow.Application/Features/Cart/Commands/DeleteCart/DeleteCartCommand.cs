using EventFlow.Application.Abstractions.CQRS;

namespace EventFlow.Application.Features.Cart.Commands.DeleteCart;

public class DeleteCartCommand : ICommand
{
    public required string Id { get; set; }
}
