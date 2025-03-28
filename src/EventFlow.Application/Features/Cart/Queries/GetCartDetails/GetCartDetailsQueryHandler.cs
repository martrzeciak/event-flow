using EventFlow.Application.Abstractions.CQRS;
using EventFlow.Application.Common;
using EventFlow.Application.DTOs;
using EventFlow.Domain.Entities;
using EventFlow.Domain.Interfaces;
using Mapster;

namespace EventFlow.Application.Features.Cart.Queries.GetCartDetails;

public class GetCartDetailsQueryHandler(ICartService cartService) 
    : IQueryHandler<GetCartDetailsQuery, ShoppingCartDto>
{
    public async Task<Result<ShoppingCartDto>> Handle(GetCartDetailsQuery request, 
        CancellationToken cancellationToken)
    {
        var cart = await cartService.GetCartAsync(request.Id);

        var cartToReturn = cart ?? new ShoppingCart { Id = request.Id };

        return cartToReturn.Adapt<ShoppingCartDto>();
    }
}
