using Microsoft.AspNetCore.Identity;

namespace Angular_WebApi.Utilities.Extensions;

public static class ResultExtensions
{
    public static string GetIdentityErrors(this IdentityResult result)
    {
        if (result.Succeeded)
            return "No errors, operation succeeded.";

        // Aggregate the errors into a single string
        return string.Join("; ", result.Errors.Select(e => $"{e.Code}: {e.Description}"));
    }
}
