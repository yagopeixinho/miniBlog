using MB.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Data;

public class BlogDbContext : DbContext
{
    public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
    { }

    public DbSet<BlogPost> BlogPost { get; set; }
    public DbSet<Comment> Comment { get; set; }
}