using EventFlow.Application.Abstractions.CQRS;
using EventFlow.Application.DTOs;

namespace EventFlow.Application.Features.Cart.Queries.GetCartDetails;

public class GetCartDetailsQuery : IQuery<ShoppingCartDto>
{
    public required string Id { get; set; }
}
