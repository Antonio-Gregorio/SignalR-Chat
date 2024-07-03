using CLI.Enums;
using CLI.Signal;
using CLI.views;

SignalRAdapter hub = new SignalRAdapter("http://localhost:5118/chat-hub");

await hub.StartAdapter();

await hub.SetUserName(MenuView.Nickname());

string? chatId = null;

RoomOption roomOptionSelected = MenuView.JoinOrCreateRoom();

if (roomOptionSelected == RoomOption.Create)
{
    chatId = await hub.CreateChat();
}
else
{
    chatId = MenuView.JoinRoom();
}

await hub.JoinChat(chatId);

MenuView.InfoRoom(chatId);

while (true)
{
        var message = Console.ReadLine();
        ClearCurrentConsoleLine();
        
        if (message?.Length > 0)
        {
            await hub.Send(message);
        }
}

void ClearCurrentConsoleLine()
{
    Console.CursorTop--;
    Console.Write("".PadRight(Console.WindowWidth, ' '));
    Console.CursorLeft = 0;
}