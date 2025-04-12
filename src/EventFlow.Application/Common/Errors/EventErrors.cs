namespace EventFlow.Application.Common.Errors;

public static class EventError
{
    public static readonly Error NotFound = new(
        "404",
        "Event not found.");

    public static readonly Error CategoryNotFound = new(
        "404",
        "Category not found.");
}
