namespace SimpleBlazorChatApp.Hubs;

public interface IChatClient
{
    public Task ReceiveMessage(string user, string message);

    public Task UserConnected(string user);

    public Task UserDisconnected(string user);
}
