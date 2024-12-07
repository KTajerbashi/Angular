using Angular_WebApi.ApplicationBases.Models;
using Angular_WebApi.Utilities;
using MediatR;

namespace Angular_WebApi.ApplicationBases.Handlers;

public interface IQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IQuery<TResponse>
{
}
public abstract class QueryHandler<TRequest, TResponse> : IQueryHandler<TRequest, TResponse>
    where TRequest : IQuery<TResponse>
{
    protected readonly UtilitiesServices UtilitiesServices;

    protected QueryHandler(UtilitiesServices utilitiesServices)
    {
        UtilitiesServices = utilitiesServices;
    }

    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}