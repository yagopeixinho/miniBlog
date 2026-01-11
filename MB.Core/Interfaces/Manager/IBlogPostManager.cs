using MB.Manager.DTO.Requests;
using MB.Manager.DTO.Responses;

namespace MB.Manager.Interfaces.Manager;

public interface IBlogPostManager
{
    Task<List<ReturnBlogPostDTO>> GetAllPosts();
    Task<ReturnBlogPostDTO> GetByIdAsync(int id);
    Task<ReturnBlogPostDTO> CreateAsync(CreateBlogPostDto request);

}