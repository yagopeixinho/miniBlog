

namespace MB.Manager.DTO.Requests;

public class CreateBlogPostDto
{
    public string Title { get; set; } = default!;
    public string Content { get; set; }
}