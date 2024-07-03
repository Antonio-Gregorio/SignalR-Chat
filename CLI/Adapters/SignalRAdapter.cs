using Chat.Shared.ViewModels;
using Microsoft.AspNetCore.SignalR.Client;

namespace CLI.Signal;

public class SignalRAdapter
{
    private HubConnection _conn;

    public SignalRAdapter(string url)
    {
        var uri = new Uri(url);
        var hubUrl = url;

        _conn = new HubConnectionBuilder()
            .WithUrl(hubUrl)
            .WithAutomaticReconnect()
            .Build();
        
        _conn.On<MessageObject>("ReceiveMessage", ReceiveMessage);
        _conn.On<MessageObject>("ReceiveMessageWhisper", ReceiveMessageWhisper);
        _conn.On<UsuarioViewModel>("JoinUser", JoinUser);
    }

    public async Task StartAdapter()
    {
        await _conn.StartAsync();
    }

    public async Task Send(string message)
    {
        await _conn.SendAsync("Send", message);
    }

    public async Task<string> CreateChat()
    {
        var chatId = await _conn.InvokeAsync<string>("CreateChat");
        
        return chatId;
    }

    public async Task JoinChat(string chatId)
    {
        await _conn.SendAsync("JoinChat", chatId);
    }

    public async Task SetUserName(string name)
    {
        await _conn.SendAsync("SetUserName", name);
    }

    private void ReceiveMessage(MessageObject messageObject)
    {
        Console.ForegroundColor = messageObject.usuario.Color;
        Console.WriteLine($"{messageObject.usuario.Name}: {messageObject.message}");
        Console.ResetColor();
    }

    private void ReceiveMessageWhisper(MessageObject messageObject)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"(Whisper) {messageObject.usuario.Name}: {messageObject.message}");
        Console.ResetColor();
    }

    private void JoinUser(UsuarioViewModel usuario)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"{usuario.Name} Acabou de entrar no chat!");
        Console.ResetColor();
    }
}