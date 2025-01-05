using MediatR;

namespace Angular.ApplicationLibrary.BaseApplication.Pattern.MediatR.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine($"LoggingBehavior : Handling {typeof(TRequest).Name}");
        var response = await next();
        Console.WriteLine($"LoggingBehavior : Handled {typeof(TRequest).Name}");
        Console.ResetColor();
        return response;
    }
}
