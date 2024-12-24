using static Angular_WebApi.Providers.SignalRHubs.SignalRHubContainer;

namespace Angular_WebApi.Providers.SignalRHubs.DI;

public static class SignalRExtensions
{
    public static IServiceCollection AddSignalRServices(this IServiceCollection services)
    {
        services.AddSignalR();
        return services;
    }

    public static WebApplication UserSignalR(this WebApplication app)
    {
        // Map SignalR hubs
        app.MapHub<ChatHub>("/chatHub");
        app.MapHub<OnlineUserHub>("/hubs/onlineUsers");
        return app;
    }
}
