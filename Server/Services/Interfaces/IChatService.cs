using Chat.Shared.ViewModels;
using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces;

public interface IChatService
{
    public ChatViewModel CreateChat();
    public ChatViewModel JoinChat(UsuarioViewModel user, string chatId);
    public UsuarioModel? GetUser(string chatId, string username);
}
