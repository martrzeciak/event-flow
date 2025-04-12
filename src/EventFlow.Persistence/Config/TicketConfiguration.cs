using EventFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventFlow.Persistence.Config;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.Property(t => t.Price).HasColumnType("decimal(18,2)");
        builder.Property(x => x.TicketType).HasConversion(
            o => o.ToString(),
            o => Enum.Parse<TicketType>(o)
        );
    }
}
