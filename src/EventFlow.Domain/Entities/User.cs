using Microsoft.AspNetCore.Identity;

namespace EventFlow.Domain.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}
