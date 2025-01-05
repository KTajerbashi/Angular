using Angular.ApplicationLibrary.BaseApplication.Pattern.MediatR.Commands;
using MediatR;

namespace Angular.ApplicationLibrary.BaseApplication.Pattern.MediatR.Queries;

public interface IQuery<TReturn> : IRequest<TReturn> { }
public abstract class Query<TReturn> : IRequest<TReturn> { }

public interface IQueryHandler<TQuery, TReturn> : IRequestHandler<TQuery, TReturn>
    where TQuery : Query<TReturn>
{ }

public abstract class QueryHandler<TQuery, TReturn> : IQueryHandler<TQuery, TReturn>
    where TQuery : Query<TReturn>
{
    protected readonly ProviderServices Providers;
    protected QueryHandler(ProviderServices providers)
    {
        Providers = providers;
    }
    public abstract Task<TReturn> Handle(TQuery request, CancellationToken cancellationToken);
}



