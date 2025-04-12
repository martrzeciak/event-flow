namespace EventFlow.Application.Common.Errors;

public static class PaymentErrors
{
    public static readonly Error CartProblem = new(
        "400",
        "Problem with your cart.");
}
