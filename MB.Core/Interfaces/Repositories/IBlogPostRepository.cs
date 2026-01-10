using MB.Core.Entities;

namespace MB.Manager.Interfaces.Repositories;

public interface IBlogPostRepository
{
    Task AddAsync(BlogPost request);
    Task<BlogPost> GetByIdAsync(int id);
    Task<IReadOnlyList<BlogPost>> GetAllPostsAsync();

}