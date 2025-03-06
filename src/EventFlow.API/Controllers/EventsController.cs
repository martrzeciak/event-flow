using EventFlow.Application.Common;
using EventFlow.Application.DTOs;
using EventFlow.Application.Features.Events.GetEvents;
using Microsoft.AspNetCore.Mvc;

namespace EventFlow.API.Controllers;

public class EventsController() : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<PagedList<EventQueryDto>>> GetEvents([FromQuery] PagingParams pagingParams)
    {
        return HandlePagedResult(await Mediator.Send(new GetEventListsQuery { Params = pagingParams }));
    }
}
