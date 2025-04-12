using EventFlow.Application.Abstractions.CQRS;
using EventFlow.Application.Common;
using EventFlow.Application.Common.Errors;
using EventFlow.Domain.Interfaces;
using MediatR;

namespace EventFlow.Application.Features.Cart.Commands.DeleteCart;

public class DeleteCartCommandHandler(ICartService cartService)
    : ICommandHandler<DeleteCartCommand>
{
    public async Task<Result<Unit>> Handle(DeleteCartCommand request, 
        CancellationToken cancellationToken)
    {
        var result = await cartService.DeleteCartAsync(request.Id);

        return result
            ? Result.Success(Unit.Value)
            : Result.Failure<Unit>(CartError.DeleteFailed);
    }
}
