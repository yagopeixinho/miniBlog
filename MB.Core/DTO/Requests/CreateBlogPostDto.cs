

namespace MB.Manager.DTO.Requests;

public class CreateBlogPostDto
{
    public string Name { get; set; } = default!;
    public float Price { get; set; }
    public string Description { get; set; }
}