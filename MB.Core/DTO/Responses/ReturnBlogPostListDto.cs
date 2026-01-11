using MB.Manager.DTO.Requests;

namespace MB.Core.DTO.Responses;

public class ReturnBlogPostListDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int CommentsCount { get; set; }
}