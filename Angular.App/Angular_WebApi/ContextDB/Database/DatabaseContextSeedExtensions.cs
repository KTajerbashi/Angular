namespace Angular_WebApi.ContextDB.Database;

public static class DatabaseContextSeedExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<DatabaseContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }

}

public abstract class Roles
{
    public const string Administrator = nameof(Administrator);
}