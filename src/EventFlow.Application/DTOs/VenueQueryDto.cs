namespace EventFlow.Application.DTOs;

public class VenueQueryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public required AddressQueryDto Address { get; set; }
}
