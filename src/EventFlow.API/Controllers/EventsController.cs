using EventFlow.Domain.Entities;
using EventFlow.Persistence.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventFlow.API.Controllers;

public class EventsController(AppDbContext context) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Event>>> GetEvents()
    {
        return await context.Events.ToListAsync();
    }
}
