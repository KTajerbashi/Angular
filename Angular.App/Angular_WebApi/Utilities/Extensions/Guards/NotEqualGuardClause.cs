﻿namespace Angular_WebApi.Utilities.Extensions.Guards;

public static class NotEqualGuardClause
{
    public static void NotEqual<T>(this Guard guard, T value, T targetValue, string message)
    {
        if (string.IsNullOrEmpty(message))
            throw new ArgumentNullException("Message");

        if (Equals(value, targetValue))
            throw new InvalidOperationException(message);
    }
}