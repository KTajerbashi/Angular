using MediatR;

namespace Angular.ApplicationLibrary.BaseApplication.Pattern.MediatR.Commands;

/// <summary>
/// 
/// </summary>
public interface ICommand<TReturn> : IRequest<TReturn> { }

/// <summary>
/// 
/// </summary>
public abstract class Command<TReturn> : ICommand<TReturn> { }

/// <summary>
/// 
/// </summary>
public interface ICommand : IRequest { }

/// <summary>
/// 
/// </summary>
public abstract class Command : ICommand { }

/// <summary>
/// 
/// </summary>
/// <typeparam name="TCommand"></typeparam>
public interface ICommandHandler<TCommand> : IRequestHandler<TCommand>
    where TCommand : Command
{ }
/// <summary>
/// 
/// </summary>
/// <typeparam name="TCommand"></typeparam>
public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand>
    where TCommand : Command
{
    public abstract Task Handle(TCommand request, CancellationToken cancellationToken);
}

/// <summary>
/// 
/// </summary>
/// <typeparam name="TCommand"></typeparam>
/// <typeparam name="TReturn"></typeparam>
public interface ICommandHandler<TCommand,TReturn> : IRequestHandler<TCommand, TReturn>
    where TCommand : Command<TReturn>
{ }

/// <summary>
/// 
/// </summary>
/// <typeparam name="TCommand"></typeparam>
/// <typeparam name="TReturn"></typeparam>
public abstract class CommandHandler<TCommand, TReturn> : ICommandHandler<TCommand, TReturn>
    where TCommand : Command<TReturn>
{
    public abstract Task<TReturn> Handle(TCommand request, CancellationToken cancellationToken);
}