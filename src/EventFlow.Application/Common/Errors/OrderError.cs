namespace EventFlow.Application.Common.Errors;

public static class OrderError
{
    public static readonly Error OrderNotFound = new(
        "404",
        "Order not found.");

    public static readonly Error PaymentIntentNotFound = new(
        "400",
        "Payment intent not found");

    public static readonly Error OrderProblem = new(
        "400",
        "Problem with the order");

    public static readonly Error CreateFailed = new(
        "400",
        "Problem creating order");
}
