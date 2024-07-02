using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;
using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces;

[Service<IChatService>]
public class ChatService(IChatsService chatsService) : IChatService
{
    
    
}