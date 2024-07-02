using Microsoft.AspNetCore.SignalR;
using WebApplication1.Services.Interfaces;

namespace WebApplication1;

public class ChatHub(IChatService chatService, IUsuarioService usuarioService) : Hub
{
    public override Task OnConnectedAsync()
    {
        return Task.CompletedTask;
    }
    
    public async Task BroadcastMessage(string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", $"{Context.ConnectionId}: {message}");
    }
}