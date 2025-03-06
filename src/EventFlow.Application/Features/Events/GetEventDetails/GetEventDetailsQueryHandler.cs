﻿using EventFlow.Application.Abstractions.CQRS;
using EventFlow.Application.Common;
using EventFlow.Application.Common.Errors;
using EventFlow.Application.DTOs;
using EventFlow.Persistence.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace EventFlow.Application.Features.Events.GetEventDetails;

public class GetEventDetailsQueryHandler(AppDbContext context)
    : IQueryHandler<GetEventDetailsQuery, EventQueryDto>
{
    public async Task<Result<EventQueryDto>> Handle(GetEventDetailsQuery request, 
        CancellationToken cancellationToken)
    {
        var query = await context.Events
            .ProjectToType<EventQueryDto>()
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (query == null)
            return Result.Failure<EventQueryDto>(EventErrors.NotFound(request.Id));

        return Result.Success(query);
    }
}
