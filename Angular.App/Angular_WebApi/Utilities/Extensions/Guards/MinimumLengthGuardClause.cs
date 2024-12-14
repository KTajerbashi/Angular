﻿using System.Collections;

namespace Angular_WebApi.Utilities.Extensions.Guards;

public static class MinimumLengthGuardClause
{
    public static void MinimumLength(this Guard guard, string value, int minimumLength, string message)
    {
        if (string.IsNullOrEmpty(message))
            throw new ArgumentNullException("Message");

        if (value.Length < minimumLength)
            throw new InvalidOperationException(message);
    }
    public static void MinimumLength<T>(this Guard guard, ICollection value, int minimumLength, string message)
    {
        if (string.IsNullOrEmpty(message))
            throw new ArgumentNullException("Message");

        if (value.Count < minimumLength)
            throw new InvalidOperationException(message);
    }
}