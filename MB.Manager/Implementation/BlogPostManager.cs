using MB.Core.Entities;
using MB.Manager.DTO.Requests;
using MB.Manager.DTO.Responses;
using MB.Manager.Interfaces.Manager;
using MB.Manager.Interfaces.Repositories;

namespace MB.Manager.Implementation;

public class BlogPostManager : IBlogPostManager
{
    private readonly IBlogPostRepository _repository;

    public BlogPostManager(IBlogPostRepository repository)
    {
        _repository = repository;
    }

    public async Task<ReturnBlogPostDTO[]> GetAllPosts()
    {
        var posts = await _repository.GetAllPostsAsync();

        return [.. posts
            .Select(p => new ReturnBlogPostDTO
            {
                Title = p.Title,
                Content = p.Content
            })];
    }

    public async Task<ReturnBlogPostDTO> GetByIdAsync(int id)
    {
        var user = await _repository.GetByIdAsync(id);

        return new ReturnBlogPostDTO
        {
            Title = user.Title,
            Content = user.Content,
        };
    }

    public async Task<ReturnBlogPostDTO> CreateAsync(CreateBlogPostDto request)
    {
        var product = new BlogPost
        {
            Content = "Teste",
            Title = request.Description
        };

        await _repository.AddAsync(product);

        return new ReturnBlogPostDTO();
    }
}
