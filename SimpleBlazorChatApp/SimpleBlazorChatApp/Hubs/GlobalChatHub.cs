using Microsoft.AspNetCore.SignalR;
using static SimpleBlazorChatApp.Client.Pages.Chat;

namespace SimpleBlazorChatApp.Hubs;

public class GlobalChatHub : Hub<IChatClient>
{
    private static readonly List<string> _connections = [];

    public Task SendGlobalMessage(string user, string message)
    {
        Clients.All.ReceiveMessage(user, message);

        return base.OnConnectedAsync();
    }

    public Task SendMessage(string user, string target, string message)
    {
        Clients.Client(user).ReceiveWhisperMessage(user, message, Perspective.Sender);
        Clients.Client(target).ReceiveWhisperMessage(target, message, Perspective.Receiver);

        return base.OnConnectedAsync();
    }


    public override Task OnConnectedAsync()
    {
        Clients.All.UserConnected(Context.ConnectionId);
        _connections.Add(Context.ConnectionId);
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        Clients.All.UserDisconnected(Context.ConnectionId);
        _connections.Remove(Context.ConnectionId);
        return base.OnDisconnectedAsync(exception);
    }

    public List<string> GetOnlineUsers()
    {
        return [.. _connections];
    }
}
