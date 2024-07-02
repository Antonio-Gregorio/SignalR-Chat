using TakasakiStudio.Lina.AutoDependencyInjection;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;
using WebApplication1.Enums;
using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services;

[Service<IChatsService>(LifeTime.Singleton)]
public class ChatsService(IChatService chatService) : IChatsService
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
}