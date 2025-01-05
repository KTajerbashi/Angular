using MediatR;

namespace Angular.ApplicationLibrary.BaseApplication.Pattern.MediatR.Behaviors;

public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        // Add your authorization logic here
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Authorizing {typeof(TRequest).Name}");
        Console.ResetColor();

        // Example: Throw exception if not authorized
        // throw new UnauthorizedAccessException("Not authorized to perform this action");

        return await next();
    }
}
