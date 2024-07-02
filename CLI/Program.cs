using Microsoft.AspNetCore.SignalR.Client;

Console.WriteLine("CHAT TAHC");

var client = new HubConnectionBuilder().WithUrl("http://localhost:5118/chat-hub").Build();

client.On<string>("ReceiveMessage", obj => {
    Console.WriteLine(obj);
});

await client.StartAsync();

while (true)
{
    var message = Console.ReadLine();
    if (message?.Length > 0)
    {
        await client.SendAsync("BroadcastMessage", message);
    }
}