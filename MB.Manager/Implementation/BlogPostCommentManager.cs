using MB.Core.DTO.Requests;
using MB.Core.Entities;
using MB.Core.Interfaces.Manager;
using MB.Core.Interfaces.Repositories;
using MB.Manager.DTO.Requests;

namespace MB.Manager.Implementation;

public class BlogPostCommentManager(
    IBlogPostCommentRepository commentRepository,
    IBlogPostRepository blogPostRepository) : IBlogPostCommentManager
{
    private readonly IBlogPostRepository _blogPostRepository = blogPostRepository;
    private readonly IBlogPostCommentRepository _commentRepository = commentRepository;

    public async Task<ReturnCommentDTO> CreateAsync(int postId, ReturnCommentDto request)
    {
        var post = await _blogPostRepository.GetByIdAsync(postId);
        if (post is null)
            throw new KeyNotFoundException($"Post com id {postId} não encontrado");

        var comment = new Comment
        {
            Text = request.Text,
            BlogPostId = post.Id,
        };

        await _commentRepository.AddAsync(comment);

        return new ReturnCommentDTO
        {
            Id = comment.Id,
            Text = comment.Text
        };
    }
}
