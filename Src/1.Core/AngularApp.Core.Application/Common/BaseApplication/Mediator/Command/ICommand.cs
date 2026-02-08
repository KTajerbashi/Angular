

using MediatR;

namespace AngularApp.Core.Application.Common.BaseApplication.Mediator.Command;

public interface ICommand : IRequest { }
public interface ICommand<TResult> : IRequest<TResult> { }

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
{
}
public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
{
    protected readonly ProviderServices Provider;

    protected CommandHandler(ProviderServices provider)
    {
        Provider = provider;
    }

    public abstract Task Handle(TCommand request, CancellationToken cancellationToken);
}
public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse> where TCommand : ICommand<TResponse>
{
}
public abstract class CommandHandler<TCommand, TRequest> : ICommandHandler<TCommand, TRequest> where TCommand : ICommand<TRequest>
{
    protected readonly ProviderServices Provider;

    protected CommandHandler(ProviderServices provider)
    {
        Provider = provider;
    }
    public abstract Task<TRequest> Handle(TCommand request, CancellationToken cancellationToken);
}