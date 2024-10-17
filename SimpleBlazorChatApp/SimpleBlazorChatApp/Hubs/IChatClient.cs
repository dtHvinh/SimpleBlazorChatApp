using static SimpleBlazorChatApp.Client.Pages.Chat;

namespace SimpleBlazorChatApp.Hubs;

public interface IChatClient
{
    public Task ReceiveMessage(string user, string message);
    public Task ReceiveWhisperMessage(string user, string message, Perspective perspective);
    public Task UserConnected(string user);
    public Task UserDisconnected(string user);
}
