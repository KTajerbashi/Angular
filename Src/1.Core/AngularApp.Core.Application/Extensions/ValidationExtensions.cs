namespace AngularApp.Core.Application.Extensions;

public static class ValidationExtensions
{
    public static bool IsValidString(this string value)
    {
        // نه null، نه خالی، نه فقط فاصله
        return !string.IsNullOrWhiteSpace(value);
    }

    public static bool IsNull(this string value)
    {
        return value is null;
    }

    public static bool IsNotNull(this string value)
    {
        return value is not null;
    }

}
