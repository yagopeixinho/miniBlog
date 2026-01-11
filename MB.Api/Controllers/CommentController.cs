using MB.Manager.DTO.Requests;
using MB.Manager.Interfaces.Manager;
using Microsoft.AspNetCore.Mvc;

namespace MB.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ApiControllerBase
{
    private readonly IBlogPostCommentManager _blogPostCommentManager;

    public CommentController(IBlogPostCommentManager productManager)
    {
        _blogPostCommentManager = productManager ?? throw new ArgumentNullException(nameof(productManager));
    }

    [HttpPost("{postId}/comments")]
    public async Task<ApiResponse<ReturnCommentDTO>> CreateComment(
        int postId,
        [FromBody] ReturnCommentDto request)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            return ApiResponse.Fail<ReturnCommentDTO>("Dados inválidos", errors);
        }

        try
        {
            var comment = await _blogPostCommentManager.CreateAsync(postId, request);
            return ApiResponse.Success(comment, "Comentário criado com sucesso");
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail<ReturnCommentDTO>(ex.Message);
        }
    }

}