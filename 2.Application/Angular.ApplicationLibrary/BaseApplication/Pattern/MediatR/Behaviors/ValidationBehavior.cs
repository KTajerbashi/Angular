using FluentValidation;
using MediatR;

namespace Angular.ApplicationLibrary.BaseApplication.Pattern.MediatR.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TRequest>
{
    private readonly IEnumerable<IValidator<TRequest>> _validator;
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
    {
        _validator = validator;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.WriteLine("ValidationBehavior");
        // pre
        var context = new ValidationContext<TRequest>(request);

        var faliures = _validator
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(s => s != null)
                .ToList();

        if (faliures.Any())
        {
            // it not prefer to throw an exception instead of return TResponse
            throw new FluentValidation.ValidationException(faliures);
        }
        // next();

        return await next();
        // post
    }
}