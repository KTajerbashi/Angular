using System.ComponentModel;

namespace AngularApp.Core.Application.Utilities.DataGrid;

public enum ColumnType
{
    [Description("تاریخ")]
    DateTime = 1,

    [Description("عدد")]
    Number = 2,

    [Description("رشته")]
    String = 3,

    [Description("شمارشی")]
    Enum = 4,

    [Description("بله - خیر")]
    Boolean = 5,

    [Description("لیست")]
    List = 6,

    [Description("دارای عکس")]
    HasImage = 7,

    [Description("عدد قابل نال بودن")]
    NumberNullable = 8,

    [Description("عدد اعشاری")]
    NumberWithDecimals = 9,

    [Description("مسیر عکس")]
    ImageUrl = 10,


    [Description("مسیر  نسبی عکس")]
    ImageRelativeUrl = 12,



    [Description("لینک")]
    Link = 11,
}
