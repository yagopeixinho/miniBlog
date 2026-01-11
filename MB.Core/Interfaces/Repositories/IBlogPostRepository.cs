using MB.Core.Entities;

namespace MB.Core.Interfaces.Repositories;

public interface IBlogPostRepository
{
    Task<IReadOnlyList<BlogPost>> GetAllPostsAsync(); 
    Task AddAsync(BlogPost request);
    Task<BlogPost> GetByIdAsync(int id);
}