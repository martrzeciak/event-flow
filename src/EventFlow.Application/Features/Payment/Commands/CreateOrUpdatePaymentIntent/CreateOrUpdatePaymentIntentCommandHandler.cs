using EventFlow.Application.Abstractions.CQRS;
using EventFlow.Application.Common;
using EventFlow.Application.Common.Errors;
using EventFlow.Application.DTOs;
using EventFlow.Domain.Interfaces;
using Mapster;

namespace EventFlow.Application.Features.Payment.Commands.CreateOrUpdatePaymentIntent;

public class CreateOrUpdatePaymentIntentCommandHandler(IPaymentService paymentService)
    : ICommandHandler<CreateOrUpdatePaymentIntentCommand, ShoppingCartDto>
{
    public async Task<Result<ShoppingCartDto>> Handle(CreateOrUpdatePaymentIntentCommand request,
        CancellationToken cancellationToken)
    {
        var cart = await paymentService.CreateOrUpdatePaymentIntent(request.CartId);

        if (cart is null) return Result.Failure<ShoppingCartDto>(PaymentErrors.CartProblem);

        return cart.Adapt<ShoppingCartDto>();
    }
}
