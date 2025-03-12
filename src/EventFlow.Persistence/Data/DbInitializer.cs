using EventFlow.Persistence.Data;

public class DbInitializer
{
    public static async Task SeedData(AppDbContext context)
    {
        if (context.Events.Any()) return;

        var events = DataGenerator.EventFaker.Generate(100);

        await context.Events.AddRangeAsync(events);
        context.Events.AddRange(events);
        await context.SaveChangesAsync();
    }

}