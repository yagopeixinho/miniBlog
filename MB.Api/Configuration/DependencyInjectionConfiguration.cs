using MB.Core.Interfaces.Manager;
using MB.Core.Interfaces.Repositories;
using MB.Infrastructure.Repositories;
using MB.Manager.Implementation;

namespace MB.Api.Configuration;

public static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        // Repositories
        services.AddScoped<IBlogPostRepository, BlogPostRepository>();
        services.AddScoped<IBlogPostCommentRepository, BlogPostCommentRepository>();

        // Manager
        services.AddScoped<IBlogPostCommentManager, BlogPostCommentManager>();
        services.AddScoped<IBlogPostManager, BlogPostManager>();

    }
}