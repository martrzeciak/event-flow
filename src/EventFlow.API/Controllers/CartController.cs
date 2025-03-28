using EventFlow.Application.DTOs;
using EventFlow.Application.Features.Cart.Commands.DeleteCart;
using EventFlow.Application.Features.Cart.Commands.UpdateCart;
using EventFlow.Application.Features.Cart.Queries.GetCartDetails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventFlow.API.Controllers;

[AllowAnonymous]
public class CartController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<ShoppingCartDto>> GetCartDetails(string id)
    {
        return HandleResult(await Mediator.Send(new GetCartDetailsQuery { Id = id }));
    }

    [HttpPost]
    public async Task<ActionResult<ShoppingCartDto>> UpdateCart(ShoppingCartDto shoppingCartDto)
    {
        return HandleResult(await Mediator.Send(new UpdateCartCommand { ShoppingCartDto = shoppingCartDto }));
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteCart(string id)
    {
        return HandleResult(await Mediator.Send(new DeleteCardCommand { Id = id }));
    }
}
