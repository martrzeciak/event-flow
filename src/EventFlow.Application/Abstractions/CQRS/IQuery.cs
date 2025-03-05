using EventFlow.Application.Common;
using MediatR;

namespace EventFlow.Application.Abstractions.CQRS;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}