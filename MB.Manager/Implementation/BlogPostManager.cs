using MB.Core.DTO.Responses;
using MB.Core.Entities;
using MB.Core.Interfaces.Manager;
using MB.Core.Interfaces.Repositories;
using MB.Manager.DTO.Requests;

namespace MB.Manager.Implementation;

public class BlogPostManager(IBlogPostRepository repository) : IBlogPostManager
{
    private readonly IBlogPostRepository _repository = repository;

    public async Task<List<ReturnBlogPostListDTO>> GetAllPosts()
    {
        var posts = await _repository.GetAllPostsAsync();

        return [.. posts.Select(p => new ReturnBlogPostListDTO
        {
            Id = p.Id,
            Title = p.Title,
            Content = p.Content,
            CommentsCount = p.Comments?.Count ?? 0
        })];
    }

    public async Task<ReturnBlogPostDTO> GetByIdAsync(int id)
    {
        var post = await _repository.GetByIdAsync(id);
        if (post is null)
            throw new KeyNotFoundException($"Post com id {id} não encontrado.");

        return new ReturnBlogPostDTO
        {
            Id = post.Id,
            Title = post.Title,
            Content = post.Content,
            Comments = post.Comments?.Select(c => new ReturnCommentDTO
            {
                Id = c.Id,
                Text = c.Text
            }).ToList() ?? new List<ReturnCommentDTO>(),
            CommentsCount = post.Comments?.Count ?? 0
        };
    }

    public async Task<ReturnBlogPostDTO> CreateAsync(CreateBlogPostDto request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var post = new BlogPost
        {
            Title = request.Title,
            Content = request.Content
        };

        await _repository.AddAsync(post);

        return new ReturnBlogPostDTO
        {
            Id = post.Id,
            Title = post.Title,
            Content = post.Content,
            Comments = new List<ReturnCommentDTO>(),
            CommentsCount = 0
        };
    }
}
