using MediatR;

namespace Angular_WebApi.ApplicationBases.Models;

public interface IQuery<TModel> : IRequest<TModel>
{
}
public abstract class Query<TModel> : IQuery<TModel>
{
}

