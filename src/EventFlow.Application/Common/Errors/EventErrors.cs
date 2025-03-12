namespace EventFlow.Application.Common.Errors;

public static class EventErrors
{
    public static Error NotFound(Guid actorId) => new(
        "404",
        $"Event with ID {actorId} not found.");

    public static readonly Error CategoryNotFound = new(
        "404",
        "Category not found.");
}
