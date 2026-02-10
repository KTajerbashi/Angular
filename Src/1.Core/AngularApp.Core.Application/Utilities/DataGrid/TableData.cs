namespace AngularApp.Core.Application.Utilities.DataGrid;

public class TableData<T>
{
    public List<Column> Columns { get; set; }
    public List<T> Rows { get; set; }
    public int Count { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string PageOrder { get; set; }
    public string Filters { get; set; }
}
