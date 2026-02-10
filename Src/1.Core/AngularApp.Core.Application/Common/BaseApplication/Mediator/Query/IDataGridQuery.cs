using AngularApp.Core.Application.Utilities.DataGrid;

namespace AngularApp.Core.Application.Common.BaseApplication.Mediator.Query;

public interface IDataGridQuery<TResult> : IQuery<TResult> { }

public abstract class DataGridQuery<TModel> : IDataGridQuery<TableData<TModel>>
    where TModel : BaseView
{
    public int PageNumber { get; set; }
    public int Take { get; set; }
    public string? Query { get; set; }
    public string? ColumnSort { get; set; }
}
