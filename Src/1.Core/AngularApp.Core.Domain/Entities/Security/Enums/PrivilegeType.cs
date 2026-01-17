namespace AngularApp.Core.Domain.Entities.Security.Enums;

public enum PrivilegeType : byte
{
    [Description("خواندن")]
    Read = 1,
    [Description("ایجاد")]
    Create = 2,
    [Description("ویرایش")]
    Update = 3,
    [Description("حذف")]
    Delete = 4,
    [Description("مخصوص")]
    Custom = 5,
}
