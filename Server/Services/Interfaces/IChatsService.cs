using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces;

public interface IChatsService
{
    public void AddChat(ChatModel chat);
    public ChatModel? GetChat(string chatId);
    public UsuarioModel? GetUser(string chatId, string username);
}