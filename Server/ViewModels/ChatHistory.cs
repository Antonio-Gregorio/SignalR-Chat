using WebApplication1.Models;

namespace WebApplication1.ViewModels;

public record ChatHistory(UsuarioModel User, string Message);