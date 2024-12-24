using Microsoft.AspNetCore.SignalR;

namespace Angular_WebApi.Providers.SignalRHubs;

public class SignalRHubContainer
{
    public class MessageHub : Hub
    {

    }
    public class OnlineUserHub : Hub
    {
        public async Task NotifyOnlineUsersUpdated()
        {
            await Clients.All.SendAsync("OnlineUsersUpdated");
        }
    }
}
