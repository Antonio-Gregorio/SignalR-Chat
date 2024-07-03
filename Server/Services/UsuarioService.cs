using Chat.Shared.ViewModels;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services;

[Service<IUsuarioService>()]
public class UsuarioService : IUsuarioService
{
    public UsuarioViewModel CreatePlayer(string connectionId, string name)
    {
        var usuario = new UsuarioModel(connectionId, name);

        return usuario;
    }
}