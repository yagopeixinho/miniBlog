using MB.Core.Entities;

namespace MB.Manager.Interfaces.Repositories;

public interface IBlogPostCommentRepository
{
    Task AddAsync(Comment comment);
}