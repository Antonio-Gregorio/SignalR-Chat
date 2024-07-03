using Chat.Shared.ViewModels;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;
using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services;

[Service<IChatService>]
public class ChatService(IChatsService chatsService) : IChatService
{
    public ChatViewModel CreateChat()
    {
        var chat = new ChatModel();
        
        chatsService.AddChat(chat);
        
        return chat;
    }

    public ChatViewModel JoinChat(UsuarioViewModel user, string chatId)
    {
        var chat = chatsService.GetChat(chatId);

        if (chat is null)
        {
            throw ChatException.ChatNotFound();
        }

        chat.AddUser(user);

        return chat;
    }

    public UsuarioModel? GetUser(string chatId, string username)
    {
        return chatsService.GetUser(chatId, username);
    }
}