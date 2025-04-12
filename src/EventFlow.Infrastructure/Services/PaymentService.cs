using EventFlow.Domain.Entities;
using EventFlow.Domain.Interfaces;
using EventFlow.Persistence.Data;
using Microsoft.Extensions.Configuration;
using Stripe;

namespace EventFlow.Infrastructure.Services;

public class PaymentService(IConfiguration config, ICartService
    cartService, AppDbContext context)
    : IPaymentService
{
    public async Task<ShoppingCart?> CreateOrUpdatePaymentIntent(string cartId)
    {
        StripeConfiguration.ApiKey = config["StripeSettings:SecretKey"];

        var cart = await cartService.GetCartAsync(cartId);

        if (cart is null) return null;

        foreach (var item in cart.Items)
        {
            var productItem = context.Ticket.FirstOrDefault(x => x.Id == item.TicketId);

            if (productItem is null) return null;

            if (item.Price != productItem.Price)
                item.Price = productItem.Price;
        }

        var service = new PaymentIntentService();
        PaymentIntent? intent = null;

        if (string.IsNullOrEmpty(cart.PaymentIntentId))
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = CalculateTotal(cart),
                Currency = "usd",
                PaymentMethodTypes = ["card"]
            };

            intent = await service.CreateAsync(options);
            cart.PaymentIntentId = intent.Id;
            cart.ClientSecret = intent.ClientSecret;
        }
        else
        {
            var options = new PaymentIntentUpdateOptions
            {
                Amount = CalculateTotal(cart)
            };

            intent = await service.UpdateAsync(cart.PaymentIntentId, options);
        }

        await cartService.SetCartAsync(cart);

        return cart;
    }

    private long CalculateTotal(ShoppingCart cart)
    {
        return (long)cart.Items.Sum(x => x.Quantity * (x.Price * 100));
    }
}
