using Angular.InfrastructureLibrary.Database.Initialiser;
using Microsoft.Extensions.DependencyInjection;

namespace Angular.InfrastructureLibrary.Database.Seed;

public static class DatabaseContextSeedExtensions
{
    public static async Task InitialiseDatabaseAsync(this IServiceProvider provider)
    {
        using var scope = provider.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<DatabaseContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }

}