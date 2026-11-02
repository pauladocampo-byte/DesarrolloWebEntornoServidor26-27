namespace BlogMVC.Models;

public class Post
{
    public int PostId { get; set; }
    public string Titulo { get; set; } = "";
    public string Texto { get; set; } = "";

    public DateTime FechaPublicacion { get; set; }
}
