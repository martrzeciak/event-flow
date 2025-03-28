using EventFlow.Application.Abstractions.CQRS;
using EventFlow.Application.Common;
using EventFlow.Application.Common.Errors;
using EventFlow.Application.DTOs;
using EventFlow.Domain.Entities;
using EventFlow.Domain.Interfaces;
using Mapster;

namespace EventFlow.Application.Features.Cart.Commands.UpdateCart;

public class UpdateCartCommandHandler(ICartService cartService)
    : ICommandHandler<UpdateCartCommand, ShoppingCartDto>
{
    public async Task<Result<ShoppingCartDto>> Handle(UpdateCartCommand request, 
        CancellationToken cancellationToken)
    {
        var cart = request.ShoppingCartDto.Adapt<ShoppingCart>();

        var updatedCart = await cartService.SetCartAsync(cart);

        if (updatedCart is null)
            return Result.Failure<ShoppingCartDto>(CartErrors.UpdateFailed);

        var cartToReturn = updatedCart.Adapt<ShoppingCartDto>();

        return Result.Success(cartToReturn);
    }
}
