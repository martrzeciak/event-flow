namespace EventFlow.Application.DTOs;

public class EventOrganizerQueryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ContactInfo { get; set; } = string.Empty;
}
