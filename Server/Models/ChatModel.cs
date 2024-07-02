using TakasakiStudio.Lina.Database.Models;
using TakasakiStudio.Lina.Utils.Helpers;
using WebApplication1.ViewModels;

namespace WebApplication1.Models;

public class ChatModel : BaseEntity<string>
{
    public List<ChatHistory> ChatHistory { get; set; } = new();
    public List<UsuarioModel> Users { get; set; } = new();

    public ChatModel()
    {
        Id = IdBuilder.Generate();
    }
}