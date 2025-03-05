using EventFlow.Domain.Entities;
using EventFlow.Persistence.Data;

public class DbInitializer
{
    public static async Task SeedData(AppDbContext context)
    {

        if (context.Events.Any()) return;

        var address1 = new Address
        {
            Id = Guid.NewGuid(),
            Line1 = "123 Main St",
            City = "Sample City",
            State = "SC",
            PostalCode = "12345",
            Country = "USA"
        };

        var venue1 = new Venue
        {
            Id = Guid.NewGuid(),
            Name = "Sample Venue",
            Capacity = 5000,
            Address = address1,
        };

        var organizer = new EventOrganizer
        {
            Id = Guid.NewGuid(),
            Name = "John Doe",
            ContactInfo = "john.doe@example.com",
        };
        context.EventOrganizers.Add(organizer);

        await context.SaveChangesAsync();

        var event1 = new Event
        {
            Id = Guid.NewGuid(),
            Name = "Sample Event",
            Date = DateTime.UtcNow.AddDays(10),
            Description = "This is a sample event.",
            Categories = new List<string> { "Music", "Festival" },
            Venue = venue1,
            VenueId = venue1.Id,
            Organizers = new List<EventOrganizer> { organizer }
        };

        context.Events.AddRange(event1);

        await context.SaveChangesAsync();
    }
}