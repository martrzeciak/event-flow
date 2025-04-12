namespace EventFlow.Application.Common.Errors;

public static class UserError
{
    public static readonly Error NotLoggedIn = new(
        "401",
        "User is not logged in.");
}
