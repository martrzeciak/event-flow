﻿using EventFlow.Application.Common;
using EventFlow.Application.DTOs;
using EventFlow.Application.Features.Events.Queries.GetCategoryList;
using EventFlow.Application.Features.Events.Queries.GetEventDetails;
using EventFlow.Application.Features.Events.Queries.GetEventList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventFlow.API.Controllers;

public class EventsController : BaseApiController
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<PagedList<EventQueryDto>>> GetEvents([FromQuery] EventParams eventParams)
    {
        return HandlePagedResult(await Mediator.Send(new GetEventListQuery { EventParams = eventParams }));
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<EventQueryDto>> GetEventDetails(Guid id)
    {
        return HandleResult(await Mediator.Send(new GetEventDetailsQuery { Id = id }));
    }

    [AllowAnonymous]
    [HttpGet("categories")]
    public async Task<ActionResult<List<string>>> GetCategories()
    {
        return HandleResult(await Mediator.Send(new GetCategoryListQuery()));
    }
}
