using Chat.Shared.ViewModels;

namespace WebApplication1.interfaces;

public interface IChatHubClient
{
    Task JoinUser(UsuarioViewModel usuario);
    Task ReceiveMessage(MessageObject messageObject);
    Task ReceiveMessageWhisper(MessageObject messageObject);
}