namespace EventFlow.Application.Common.Errors;

public static class CartError
{
    public static readonly Error NotFound = new(
        "400",
        "Cart not found");

    public static readonly Error UpdateFailed = new(
        "400",
        "Problem updating shopping cart.");

    public static readonly Error DeleteFailed = new(
        "400",
        "Problem deleting shopping cart.");
}
