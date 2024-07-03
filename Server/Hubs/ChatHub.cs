using Chat.Shared.ViewModels;
using Microsoft.AspNetCore.SignalR;
using WebApplication1.Enums;
using WebApplication1.Exceptions;
using WebApplication1.interfaces;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.Services.Interfaces;

namespace WebApplication1;

public class ChatHub(IChatService chatService, IUsuarioService usuarioService) : Hub<IChatHubClient>
{
    public override Task OnConnectedAsync()
    {
        return Task.CompletedTask;
    }

    public UsuarioViewModel SetUserName(string name)
    {
        var usuario = usuarioService.CreatePlayer(Context.ConnectionId, name);
        Context.Items.Add(UserContextType.User, usuario);
        return usuario;
    }

    public string CreateChat()
    {
        var chat = chatService.CreateChat();
        return chat.Id;
    }

    public async Task JoinChat(string chatId)
    {
        var usuario = (UsuarioViewModel?)Context.Items[UserContextType.User];

        if (usuario is null)
        {
            throw ChatException.CannotFindUser();
        }

        var chat = chatService.JoinChat(usuario, chatId);
        Context.Items.Remove(UserContextType.Chat);
        Context.Items.Add(UserContextType.Chat, chat);

        await Groups.AddToGroupAsync(Context.ConnectionId, chat.ChannelName);
        await Clients.GroupExcept(chat.ChannelName, Context.ConnectionId).JoinUser(usuario);
    }

    public async Task Send(string message)
    {
        ChatViewModel? chat = (ChatViewModel?) Context.Items[UserContextType.Chat];
        UsuarioViewModel? usuario = (UsuarioViewModel?) Context.Items[UserContextType.User];

        // WHISPER MESSAGE
        if (message.StartsWith("/w "))
        {
            string[] splittedMessage = message.Split(" ");
            var chatViewModel = (ChatViewModel?)Context.Items[UserContextType.Chat];

            if (chatViewModel is null)
            {
                throw ChatException.ChatNotFound();
            }

            var targetUser = chatService.GetUser(chatViewModel.Id, splittedMessage[1]);
            if (targetUser is null)
            {
                throw ChatException.CannotFindUser();
            }

            MessageObject messageObj = new MessageObject(usuario, string.Join(" ", splittedMessage[2..]));
            IEnumerable<string> usersList = [usuario.Id, targetUser.Id];
            await Clients.Clients(usersList).ReceiveMessageWhisper(messageObj);
        }
        else
        {
            if (chat is null)
            {
                throw ChatException.ChatNotFound();
            }

            if (usuario is null)
            {
                throw ChatException.CannotFindUser();
            }

            if (String.IsNullOrEmpty(message))
            {
                throw ChatException.MessageIsEmpty();
            }

            MessageObject messageObj = new MessageObject(usuario, message);
            await Clients.Group(chat.ChannelName).ReceiveMessage(messageObj);
        }
    }
}