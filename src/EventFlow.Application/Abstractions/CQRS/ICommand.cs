using EventFlow.Application.Common;
using MediatR;

namespace EventFlow.Application.Abstractions.CQRS;

public interface ICommand : IRequest<Result<Unit>>, IBaseCommand
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
{
}

public interface IBaseCommand
{
}
