using FluentValidation;
using MediatR;

namespace Angular.ApplicationLibrary.BaseApplication.Pattern.MediatR.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.WriteLine("ValidationBehavior");
        Console.ResetColor();

        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var failures = _validators
                .Select(validator => validator.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
            {
                throw new ValidationException(failures);
            }
        }

        return await next();
    }
}
