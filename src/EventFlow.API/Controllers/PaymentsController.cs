using EventFlow.Application.DTOs;
using EventFlow.Application.Features.Payment.Commands.CreateOrUpdatePaymentIntent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventFlow.API.Controllers;

[AllowAnonymous]
public class PaymentsController : BaseApiController
{
    [HttpPost("{cartId}")]
    public async Task<ActionResult<ShoppingCartDto>> CreateOrUpdatePaymentIntent(string cartId)
    {
        return HandleResult(await Mediator.Send(new CreateOrUpdatePaymentIntentCommand { CartId = cartId }));
    }
}
