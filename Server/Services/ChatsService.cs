using TakasakiStudio.Lina.AutoDependencyInjection;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;
using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services;

[Service<IChatsService>(LifeTime.Singleton)]
public class ChatsService() : IChatsService
{
    private Dictionary<string, ChatModel> _chats = new();

    public void AddChat(ChatModel chat)
    {
        if (!_chats.TryAdd(chat.Id, chat))
        {
            throw ChatException.CannotCreateRoom();
        }
    }

    public ChatModel? GetChat(string chatId)
    {
        return _chats.GetValueOrDefault(chatId);
    }

    public UsuarioModel? GetUser(string chatId, string username)
    {
        var chat = _chats.GetValueOrDefault(chatId);
        UsuarioModel? usuario = null;

        if (chat is not null)
        {
            foreach (var usuarioModel in chat.Users)
            {
                if (usuarioModel.Name == username)
                {
                    return usuarioModel;
                }
            }
        }

        return null;
    }
}