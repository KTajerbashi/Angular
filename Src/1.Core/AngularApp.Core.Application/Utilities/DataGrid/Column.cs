namespace AngularApp.Core.Application.Utilities.DataGrid;

public class Column
{
    public string Title { get; set; }

    public int OrderNumber { get; set; }
    public string Field { get; set; }
    public string Filter { get; set; }
    public ColumnType ColumnType { get; set; }
    public string EnumTitleValueName { get; set; }
    public int[] EntityTypeGroup { get; set; }
    /// <summary>
    /// ایا این ستون قابلیت ویرایش اینلاین را داشته باشد یا خیر
    /// </summary>
    public bool Editable { get; set; }

    public bool CalculateSum { get; set; }
    public bool LeftAssign { get; set; } = false;
    public bool CalculateAggregateAverage { get; set; }

    public bool NeedSubstring { get; set; } = false;
    public string FunctionName { get; set; }
}
