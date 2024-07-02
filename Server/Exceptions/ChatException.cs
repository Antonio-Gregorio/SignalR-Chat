namespace WebApplication1.Exceptions;

public class ChatException(string message) : Exception (message)
{
    public static ChatException CannotCreateRoom() => new ChatException("Não foi possível criar a sala.");
    public static ChatException CannotCreateUser() => new ChatException("Não foi possível criar o usuário.");
    public static ChatException CannotJoinRoom() => new ChatException("Não foi possível entrar na sala.");
}