namespace WebApplication1.Models;

public class UsuarioModel
{
    public readonly string Id;
    public string? Name { get; set; }

    public UsuarioModel(string id)
    {
        this.Id = id;
    }
}