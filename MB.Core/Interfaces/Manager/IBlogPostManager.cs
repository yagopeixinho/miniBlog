using MB.Core.DTO.Responses;
using MB.Manager.DTO.Requests;

namespace MB.Core.Interfaces.Manager;

public interface IBlogPostManager
{
    Task<List<ReturnBlogPostListDTO>> GetAllPosts();
    Task<ReturnBlogPostDTO> GetByIdAsync(int id);
    Task<ReturnBlogPostDTO> CreateAsync(CreateBlogPostDto request);
}