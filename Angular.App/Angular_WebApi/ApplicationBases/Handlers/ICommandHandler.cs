using Angular_WebApi.ApplicationBases.Models;
using Angular_WebApi.Utilities;
using MediatR;

namespace Angular_WebApi.ApplicationBases.Handlers;

public interface ICommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
{
}

public interface ICommandHandler<TRequest> : IRequestHandler<TRequest>
    where TRequest : ICommand
{
}


public abstract class CommandHandler<TRequest, TResponse> : ICommandHandler<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
{
    protected readonly UtilitiesServices UtilitiesServices;

    protected CommandHandler(UtilitiesServices utilitiesServices)
    {
        UtilitiesServices = utilitiesServices;
    }

    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}


public abstract class CommandHandler<TRequest> : ICommandHandler<TRequest>
    where TRequest : ICommand
{
    protected readonly UtilitiesServices UtilitiesServices;

    protected CommandHandler(UtilitiesServices utilitiesServices)
    {
        UtilitiesServices = utilitiesServices;
    }

    public abstract Task Handle(TRequest request, CancellationToken cancellationToken);
}

