namespace WebApplication1.Exceptions;

public class ChatException(string message) : Exception (message)
{
    public static ChatException CannotCreateRoom() => new ChatException("Não foi possível criar a sala.");
    public static ChatException CannotCreateUser() => new ChatException("Não foi possível criar o usuário.");
    public static ChatException CannotFindUser() => new ChatException("Não foi possível encontrar o usuário.");
    public static ChatException CannotJoinChat() => new ChatException("Não foi possível entrar na sala.");
    public static ChatException ChatNotFound() => new ChatException("Sala não encontrada.");
    public static ChatException MessageIsEmpty() => new ChatException("Mensagem está vazia.");
}