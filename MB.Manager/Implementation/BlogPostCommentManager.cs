using MB.Core.Entities;
using MB.Manager.DTO.Requests;
using MB.Manager.Interfaces.Manager;
using MB.Manager.Interfaces.Repositories;

namespace MB.Manager.Implementation;

public class BlogPostCommentManager : IBlogPostCommentManager
{
    private readonly IBlogPostRepository _blogPostRepository;
    private readonly IBlogPostCommentRepository _repository;

    public BlogPostCommentManager(
        IBlogPostCommentRepository repository,
        IBlogPostRepository blogPostRepository)
    {
        _repository = repository;
        _blogPostRepository = blogPostRepository;
    }

    public async Task<ReturnCommentDTO> CreateAsync(
        int postId,
        ReturnCommentDto request)
    {
        var post = await _blogPostRepository.GetByIdAsync(postId);

        if (post == null)
            throw new Exception("Post não encontrado");

        var comment = new Comment
        {
            Text = request.Text,
            BlogPostId = post.Id,
            //CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(comment);

        return new ReturnCommentDTO
        {
            Id = comment.Id,
            Text = comment.Text,
            //CreatedAt = comment.CreatedAt
        };
    }
}
