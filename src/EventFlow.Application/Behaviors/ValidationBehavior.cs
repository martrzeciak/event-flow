using FluentValidation;
using MediatR;

namespace EventFlow.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse>
    (IValidator<TRequest>? validator = null)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (validator == null) return await next();

        var context = new ValidationContext<TRequest>(request);

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await next();
    }
}
