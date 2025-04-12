using EventFlow.Domain.Entities;

namespace EventFlow.Domain.Interfaces;

public interface IPaymentService
{
    Task<ShoppingCart?> CreateOrUpdatePaymentIntent(string cartId);
}