using MB.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Data;

public class BlogDbContext(DbContextOptions<BlogDbContext> options) : DbContext(options)
{
    public DbSet<BlogPost> BlogPost { get; set; }
    public DbSet<Comment> Comment { get; set; }
}