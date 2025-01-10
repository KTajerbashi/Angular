using Angular.ApplicationLibrary.Models;
using Microsoft.AspNetCore.Identity;

namespace Angular.InfrastructureLibrary.Providers.Identity;

public static class IdentityResultExtensions
{
    public static Result ToApplicationResult(this IdentityResult result)
    {
        return result.Succeeded
            ? Result.Success()
            : Result.Failure(result.Errors.Select(e => e.Description));
    }
}




