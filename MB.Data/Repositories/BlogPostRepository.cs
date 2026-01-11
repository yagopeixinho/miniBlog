using MB.Core.Entities;
using MB.Infrastructure.Data;
using MB.Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Repositories;

public class BlogPostRepository : IBlogPostRepository
{
    private readonly BlogDbContext _context;

    public BlogPostRepository(BlogDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<BlogPost>> GetAllPostsAsync()
    {
        return await _context.BlogPost
            .Include(p => p.Comments)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<BlogPost> GetByIdAsync(int id)
    {
        return await _context.BlogPost
            .Include(p => p.Comments)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task AddAsync(BlogPost blogPost)
    {
        await _context.BlogPost.AddAsync(blogPost);
        await _context.SaveChangesAsync();
    }
}