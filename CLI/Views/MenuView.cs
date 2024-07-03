using CLI.Enums;

namespace CLI.views;

public class MenuView
{

    public static string Nickname()
    {
        var name = "";
        do
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Bem Vindo ao Chat Chat v5");
            Console.WriteLine("");
            Console.ResetColor();
            Console.WriteLine("Digite seu nome: ");
            name = Console.ReadLine();
            Console.Clear();
        } while (String.IsNullOrEmpty(name));
            
        return name;
    }

    public static RoomOption JoinOrCreateRoom()
    {
        RoomOption? option = null;
        
        do
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Bem Vindo ao Chat Chat v5");
            Console.WriteLine("");
            Console.ResetColor();
            Console.WriteLine("1. Entrar em uma sala.");
            Console.WriteLine("2. Criar uma sala.");
            var read = Console.ReadLine(); 
            Console.Clear();

            if (!String.IsNullOrEmpty(read))
            {
                switch (read)
                {
                    case "1":
                        option = RoomOption.Join;
                        break;
                    case "2":
                        option = RoomOption.Create;
                        break;
                }
            }
        } while (option == null);
        
        return (RoomOption) option;
    }

    public static string JoinRoom()
    {
        string? chatId = null;
        
        do
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Bem Vindo ao Chat Chat v5");
            Console.WriteLine("");
            Console.ResetColor();
            Console.WriteLine("Digite o id do chat.");
            chatId = Console.ReadLine(); 
            Console.Clear();

        } while (String.IsNullOrEmpty(chatId));
        
        return chatId;
    }

    public static void InfoRoom(string chatId)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Bem Vindo ao Chat Chat v5");
        Console.WriteLine($"Chat ID: {chatId}");
        Console.WriteLine($"Usuários Ativos: ");
        Console.WriteLine();
        Console.ResetColor();
    }
}