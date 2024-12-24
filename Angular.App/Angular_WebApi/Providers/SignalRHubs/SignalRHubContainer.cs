using Microsoft.AspNetCore.SignalR;

namespace Angular_WebApi.Providers.SignalRHubs;

public class SignalRHubContainer
{
    public class MessageHub : Hub
    {

    }

    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }

    public class OnlineUserHub : Hub
    {
        public async Task NotifyOnlineUsersUpdated()
        {
            await Clients.All.SendAsync("OnlineUsersUpdated");
        }
    }
}
