using MB.Manager.DTO.Requests;

namespace MB.Manager.DTO.Responses;

public class ReturnBlogPostDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int CommentsCount { get; set; }
    public List<ReturnCommentDTO> Comments { get; set; } = new();

}