using MB.Core.Entities;
using MB.Infrastructure.Data;
using MB.Manager.Interfaces.Repositories;

namespace MB.Infrastructure.Repositories;

public class BlogPostCommentRepository : IBlogPostCommentRepository
{
    private readonly BlogDbContext _context;

    public BlogPostCommentRepository(BlogDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Comment comment)
    {
        await _context.Comment.AddAsync(comment);
        await _context.SaveChangesAsync();
    }
}