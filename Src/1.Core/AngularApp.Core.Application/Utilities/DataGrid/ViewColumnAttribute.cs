namespace AngularApp.Core.Application.Utilities.DataGrid;

[AttributeUsage(AttributeTargets.Property)]
public class ViewColumnAttribute : System.Attribute
{
    public bool HideInGridFilters { get; set; }
    public string Title { get; set; }
    public int OrderID { get; set; }
    public string Filter { get; set; }
    public ColumnType ColumnType { get; set; }
    /// <summary>
    /// For example EntityTypeTitleValues in core > modesl > enums > EntityType.ts.
    /// this property will be used to fill grid filter dropdowns
    /// </summary>
    public string EnumTitleValueName { get; set; }

    /// <summary>
    /// this property will be used to generate string from enum in export to excel method
    /// </summary>
    public Type EnumType { get; set; }

    /// <summary>
    /// if true, the gridview will calculate the sum of the column at the bottom of the table
    /// </summary>
    public bool CalculateSum { get; set; }



    /// <summary>
    /// ایا این ستون قابلیت ویرایش اینلاین را داشته باشد یا خیر
    /// </summary>
    public bool Editable { get; set; }


    /// <summary>
    /// if true, the gridview will calculate the sum of the column at the bottom of the table
    /// </summary>
    public bool LeftAssign { get; set; } = false;



    /// <summary>
    /// if true, the gridview will calculate the Average of the column at the bottom of the table
    /// </summary>
    public bool CalculateAggregateAverage { get; set; }

    /// <summary>
    /// (int)EntityType.??
    /// </summary>
    public int[] EntityTypeGroup { get; set; }

    /// <summary>
    /// need substring column in gridview
    /// </summary>
    public bool NeedSubstring { get; set; } = false;


    public string FunctionName { get; set; }

    public ViewColumnAttribute(string title)
    {
        Title = title;
        OrderID = 0;
    }
}
