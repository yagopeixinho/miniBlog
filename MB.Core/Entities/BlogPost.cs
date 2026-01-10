namespace MB.Core.Entities;

public class BlogPost
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
