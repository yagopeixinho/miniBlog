using MB.Api.Configuration;
using MB.Core.DTO.Requests;
using MB.Core.Interfaces.Manager;
using MB.Manager.DTO.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MB.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController(IBlogPostCommentManager commentManager) : ApiControllerBase
{
    private readonly IBlogPostCommentManager _commentManager = commentManager ?? throw new ArgumentNullException(nameof(commentManager));

    [HttpPost("{postId}/comments")]
    public async Task<ApiResponse<ReturnCommentDTO>> CreateComment(
        int postId,
        [FromBody] ReturnCommentDto request)
    {
        if (!ModelState.IsValid)
        {
            return ApiResponse.Fail<ReturnCommentDTO>(
                "Dados inválidos",
                [.. ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)]
            );
        }

        try
        {
            var comment = await _commentManager.CreateAsync(postId, request);
            return ApiResponse.Success(comment, "Comentário criado com sucesso");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);

            return ApiResponse.Fail<ReturnCommentDTO>(
                "Houve um problema ao criar o comentário. Tente novamente mais tarde."
            );
        }
    }
}
