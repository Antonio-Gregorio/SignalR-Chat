using Chat.Shared.ViewModels;
using TakasakiStudio.Lina.Database.Models;
using TakasakiStudio.Lina.Utils.Helpers;
using WebApplication1.Services;

namespace WebApplication1.Models;

public class ChatModel : BaseEntity<string>
{
    public List<ChatHistory> ChatHistory { get; set; } = new();
    public List<UsuarioModel> Users { get; set; } = new();
    public string ChannelName => $"table:{Id}";

    public ChatModel()
    {
        Id = IdBuilder.Generate();
    }

    public void AddUser(UsuarioViewModel user)
    {
        Users.Add(user);
    }

    public static implicit operator ChatViewModel(ChatModel chatModel)
    {
        return new ChatViewModel(chatModel.Id, chatModel.ChannelName);
    }
}