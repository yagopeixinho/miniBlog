using MB.Core.Entities;
using MB.Core.Interfaces.Repositories;
using MB.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Repositories;

public class BlogPostRepository(BlogDbContext context) : IBlogPostRepository
{
    private readonly BlogDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task<IReadOnlyList<BlogPost>> GetAllPostsAsync()
    {
        return await _context.BlogPost
            .Include(p => p.Comments)
            .AsNoTracking() 
            .ToListAsync();
    }

    public async Task<BlogPost?> GetByIdAsync(int id)
    {
        return await _context.BlogPost
            .Include(p => p.Comments)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(BlogPost blogPost)
    {
        if (blogPost is null)
            throw new ArgumentNullException(nameof(blogPost));

        await _context.BlogPost.AddAsync(blogPost);
        await _context.SaveChangesAsync();
    }
}
