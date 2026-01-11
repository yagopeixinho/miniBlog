using MB.Core.Entities;

namespace MB.Core.Interfaces.Repositories;

public interface IBlogPostCommentRepository
{
    Task AddAsync(Comment comment);
}