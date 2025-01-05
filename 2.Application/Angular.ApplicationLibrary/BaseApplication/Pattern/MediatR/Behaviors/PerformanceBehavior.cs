using MediatR;
using System.Diagnostics;

namespace Angular.ApplicationLibrary.BaseApplication.Pattern.MediatR.Behaviors;

public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var stopwatch = Stopwatch.StartNew();
        var response = await next();
        stopwatch.Stop();
        Console.BackgroundColor = ConsoleColor.Magenta;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine($"PerformanceBehavior : {typeof(TRequest).Name} executed in {stopwatch.ElapsedMilliseconds}ms");
        Console.ResetColor();

        return response;
    }
}
