using EventFlow.Application.Common;
using EventFlow.Application.DTOs;
using EventFlow.Application.Features.Events.GetEventDetails;
using EventFlow.Application.Features.Events.GetEvents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventFlow.API.Controllers;

public class EventsController : BaseApiController
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<PagedList<EventQueryDto>>> GetEvents([FromQuery] PagingParams pagingParams)
    {
        return HandlePagedResult(await Mediator.Send(new GetEventListsQuery { Params = pagingParams }));
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<EventQueryDto>> GetEventDetails(Guid id)
    {
        return HandleResult(await Mediator.Send(new GetEventDetailsQuery { Id = id }));
    }
}
