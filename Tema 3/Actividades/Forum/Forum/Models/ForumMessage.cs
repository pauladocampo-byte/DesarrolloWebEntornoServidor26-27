namespace Forum.Models
{
    public class ForumMessage
    {
        public string Author { get; set; } = "";
        public string Subject { get; set; } = "";
        public string Body { get; set; } = "";
        public DateTime PostedAt { get; set; }
    }
}
