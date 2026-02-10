using AngularApp.Core.Application.Utilities.DataGrid;

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

public abstract class DataGridHandler<TQuery, TView> : QueryHandler<TQuery, TableData<TView>>
    where TQuery : DataGridQuery<TView>
    where TView : BaseView
{
    protected TableData<TView> Return(TQuery query, List<TView> data)
    {
        return new()
        {
            Columns = DataGridExtensions.GetColumns(typeof(TView)),
            Count = data.Count,
            Filters = "",
            PageIndex = query.PageNumber,
            PageOrder = "DESC",
            PageSize = query.Take,
            Rows = data.ToList()
        };
    }
    protected DataGridHandler(ProviderServices provider) : base(provider)
    {
    }
}