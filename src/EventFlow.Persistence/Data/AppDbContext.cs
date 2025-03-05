using EventFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventFlow.Persistence.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventOrganizer> EventOrganizers { get; set; }
    public DbSet<Venue> Venues { get; set; }
}
