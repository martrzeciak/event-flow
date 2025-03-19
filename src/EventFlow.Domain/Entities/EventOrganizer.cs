namespace EventFlow.Domain.Entities;

public class EventOrganizer : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string ContactInfo { get; set; } = string.Empty;
    public ICollection<Event> Concerts { get; set; } = [];
}
