using EventFlow.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace EventFlow.Infrastructure.Services;

public class UserService(IHttpContextAccessor contextAccessor) : IUserService
{
    public string? GetUserEmail()
    {
        var email = contextAccessor.HttpContext?.User
            .FindFirstValue(ClaimTypes.Email);

        return email;
    }
}
