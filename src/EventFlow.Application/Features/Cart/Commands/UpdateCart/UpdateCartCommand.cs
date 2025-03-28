using EventFlow.Application.Abstractions.CQRS;
using EventFlow.Application.DTOs;

namespace EventFlow.Application.Features.Cart.Commands.UpdateCart;

public class UpdateCartCommand : ICommand<ShoppingCartDto>
{
    public required ShoppingCartDto ShoppingCartDto { get; set; }
}
