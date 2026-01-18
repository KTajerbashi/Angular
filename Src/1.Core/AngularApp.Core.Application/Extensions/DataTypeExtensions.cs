namespace AngularApp.Core.Application.Extensions;

public static class DataTypeExtensions
{
    public static long ToLong(this string value) => Convert.ToInt64(value);
    public static long ToInt(this string value) => Convert.ToInt32(value);
    public static long ToByte(this string value) => Convert.ToInt16(value);
}
