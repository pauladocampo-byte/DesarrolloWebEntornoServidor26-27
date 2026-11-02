namespace BlogMVC.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }

        public string Texto { get; set; }

        public DateTime FechaPublicacion { get; set; }
    }
}
