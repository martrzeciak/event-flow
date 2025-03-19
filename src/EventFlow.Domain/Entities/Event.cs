namespace EventFlow.Domain.Entities;

public class Event : BaseEntity
{
    public string Name { get; set; } = default!;
    public DateTime Date { get; set; }
    public string Description { get; set; } = default!;
    public ICollection<string> Categories { get; set; } = [];

    public ICollection<EventOrganizer> Organizers { get; set; } = [];
    public ICollection<Ticket> Tickets { get; set; } = [];

    public Guid VenueId { get; set; }
    public Venue Venue { get; set; } = null!;
}
