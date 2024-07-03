using Chat.Shared.ViewModels;

namespace WebApplication1.Models;

public class UsuarioModel
{
    public readonly string Id;
    public readonly ConsoleColor Color; 
    public string Name { get; set; }

    public UsuarioModel(string id, string name, ConsoleColor? color = null)
    {
        this.Id = id;
        this.Name = name;

        if (color is null)
        {
            List<ConsoleColor> allowedColors = [ConsoleColor.Blue, ConsoleColor.Magenta, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.White];
            this.Color = allowedColors[Random.Shared.Next(0, allowedColors.Count)];
        }
        else
        {
            this.Color = (ConsoleColor) color;
        }
    }
    
    public static implicit operator UsuarioViewModel(UsuarioModel usuario)
    {
        return new UsuarioViewModel(usuario.Id, usuario.Name, usuario.Color );
    }
    
    public static implicit operator UsuarioModel(UsuarioViewModel usuario)
    {
        return new UsuarioModel(usuario.Id, usuario.Name, usuario.Color );
    }
}