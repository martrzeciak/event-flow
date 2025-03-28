using EventFlow.Application.Abstractions.CQRS;
using EventFlow.Application.DTOs;
using EventFlow.Domain.Entities;

namespace EventFlow.Application.Features.Cart.Queries.GetCartDetails;

public class GetCartDetailsQuery : IQuery<ShoppingCartDto>
{
    public required string Id { get; set; }
}
