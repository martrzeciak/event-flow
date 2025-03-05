namespace EventFlow.Domain.Entities;

public class Venue : BaseEntity
{
    public string Name { get; set; } = default!;
    public int Capacity { get; set; }
    public Address Address { get; set; } = default!;
    public ICollection<Event> Concerts { get; set; } = [];
}
