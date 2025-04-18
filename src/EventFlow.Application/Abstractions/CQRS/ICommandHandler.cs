﻿using EventFlow.Application.Common;
using MediatR;

namespace EventFlow.Application.Abstractions.CQRS;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Result<Unit>>
    where TCommand : ICommand
{
}

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
{
}
