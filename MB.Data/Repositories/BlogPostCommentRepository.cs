using MB.Core.Entities;
using MB.Core.Interfaces.Repositories;
using MB.Infrastructure.Data;

namespace MB.Infrastructure.Repositories;

public class BlogPostCommentRepository(BlogDbContext context) : IBlogPostCommentRepository
{
    private readonly BlogDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task AddAsync(Comment comment)
    {
        if (comment is null)
            throw new ArgumentNullException(nameof(comment));

        await _context.Comment.AddAsync(comment);
        await _context.SaveChangesAsync();
    }
}
