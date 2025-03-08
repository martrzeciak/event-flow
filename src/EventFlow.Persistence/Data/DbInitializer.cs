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

        var event2 = new Event
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

        var event12 = new Event
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

        var event13 = new Event
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

        var event14 = new Event
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

        var event15 = new Event
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

        var event16 = new Event
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

        var event17 = new Event
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

        var event18 = new Event
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

        var event19 = new Event
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

        var event120 = new Event
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

        var event1201 = new Event
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

        var event1202 = new Event
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

        var event1203 = new Event
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

        var event1204 = new Event
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

        var event1205 = new Event
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

        var event1206 = new Event
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

        var event1207 = new Event
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

        var events = new List<Event>
        {
            event1, event2, event12, event13, event14, event15, event16, event17, event18, event19,
            event120, event1201, event1202, event1203, event1204, event1205, event1206, event1207
        };

        context.Events.AddRange(events);

        await context.SaveChangesAsync();
    }
}