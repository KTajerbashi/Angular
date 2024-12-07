using MediatR;

namespace Angular_WebApi.ApplicationBases.Models;

public interface ICommand<TModel> : IRequest<TModel>
{
}
public interface ICommand : IRequest
{
}

public abstract class Command<TModel> : ICommand<TModel>
{
}

public abstract class Command : ICommand
{
}
