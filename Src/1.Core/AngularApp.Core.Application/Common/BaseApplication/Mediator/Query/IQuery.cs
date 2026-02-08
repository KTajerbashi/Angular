namespace AngularApp.Core.Application.Common.BaseApplication.Mediator.Query;

public interface IQuery<TResult> : IRequest<TResult> { }

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
{
}
public abstract class QueryHandler<TQuery, TRequest> : IQueryHandler<TQuery, TRequest> where TQuery : IQuery<TRequest>
{
    protected readonly ProviderServices Provider;

    protected QueryHandler(ProviderServices provider)
    {
        Provider = provider;
    }
    public abstract Task<TRequest> Handle(TQuery request, CancellationToken cancellationToken);
}