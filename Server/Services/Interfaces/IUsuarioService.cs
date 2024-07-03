using Chat.Shared.ViewModels;

namespace WebApplication1.Services.Interfaces;

public interface IUsuarioService
{
    public UsuarioViewModel CreatePlayer(string connectionId, string name);
}