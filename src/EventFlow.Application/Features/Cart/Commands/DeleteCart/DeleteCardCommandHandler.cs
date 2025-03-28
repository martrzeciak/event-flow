using EventFlow.Application.Abstractions.CQRS;
using EventFlow.Application.Common;
using EventFlow.Application.Common.Errors;
using EventFlow.Domain.Interfaces;
using MediatR;

namespace EventFlow.Application.Features.Cart.Commands.DeleteCart;

public class DeleteCardCommandHandler(ICartService cartService)
    : ICommandHandler<DeleteCardCommand>
{
    public async Task<Result<Unit>> Handle(DeleteCardCommand request, 
        CancellationToken cancellationToken)
    {
        var result = await cartService.DeleteCartAsync(request.Id);

        return result
            ? Result.Success(Unit.Value)
            : Result.Failure<Unit>(CartErrors.DeleteFailed);
    }
}
