using EventFlow.Domain.Entities;
using EventFlow.Domain.Entities.OrderAggregate;
using EventFlow.Persistence.Config;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventFlow.Persistence.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) 
    : IdentityDbContext<User, IdentityRole, string>(options)
{
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventOrganizer> EventOrganizers { get; set; }
    public DbSet<Venue> Venues { get; set; }
    public DbSet<Ticket> Ticket { get; set; }
    public DbSet<Order> Orders{ get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TicketConfiguration).Assembly);
    }
}
