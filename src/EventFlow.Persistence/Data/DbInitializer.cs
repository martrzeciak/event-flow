using EventFlow.Domain.Entities;
using EventFlow.Persistence.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class DbInitializer
{
    public static async Task SeedData(AppDbContext context, UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        if (await userManager.Users.AnyAsync()) return;

        var roles = new List<IdentityRole>
        {
            new() { Name = "User" },
            new() { Name = "Admin" },
            new() { Name = "Organizer" }
        };

        foreach (var role in roles)
        {
            await roleManager.CreateAsync(role);
        }

        var user = new User
        {
            FirstName = "User",
            LastName = "Localhost",
            UserName = "user@localhost",
            Email = "user@localhost"
        };

        await userManager.CreateAsync(user, "Pa$$w0rd");
        await userManager.AddToRoleAsync(user, "User");

        var admin = new User
        {
            FirstName = "Admin",
            LastName = "Localhost",
            UserName = "admin@localhost",
            Email = "admin@localhost"
        };

        await userManager.CreateAsync(admin, "Pa$$w0rd");
        await userManager.AddToRolesAsync(admin, ["Admin", "Organizer", "User"]);

        var organizer = new User
        {
            FirstName = "Organizer",
            LastName = "Localhost",
            UserName = "organizer@localhost",
            Email = "organizer@localhost"
        };

        await userManager.CreateAsync(organizer, "Pa$$w0rd");
        await userManager.AddToRolesAsync(organizer, ["Organizer", "User"]);

        if (context.Events.Any()) return;

        var events = DataGenerator.EventFaker.Generate(100);

        await context.Events.AddRangeAsync(events);
        await context.SaveChangesAsync();
    }

}