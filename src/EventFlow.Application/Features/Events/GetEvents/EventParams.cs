﻿using EventFlow.Application.Common;

namespace EventFlow.Application.Features.Events.GetEvents;

public class EventParams : PagingParams
{
    public string OrderBy { get; set; } = "date";
    public string Search { get; set; } = string.Empty;
    public string Categories { get; set; } = string.Empty;
}
