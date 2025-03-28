﻿namespace EventFlow.Application.DTOs;

public class EventQueryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string Description { get; set; } = string.Empty;
    public ICollection<TicketQueryDto> Tickets { get; set; } = [];
    public required VenueQueryDto Venue { get; set; }
    public ICollection<string> Categories { get; set; } = [];
    public ICollection<EventOrganizerQueryDto> Organizers { get; set; } = [];
}
