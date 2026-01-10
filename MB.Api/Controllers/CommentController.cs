using MB.Manager.DTO.Requests;
using MB.Manager.DTO.Responses;
using MB.Manager.Interfaces.Manager;
using Microsoft.AspNetCore.Mvc;

namespace MB.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ApiControllerBase
{
    private readonly IBlogPostManager _blogPostManager;

    public CommentController(IBlogPostManager productManager)
    {
        _blogPostManager = productManager ?? throw new ArgumentNullException(nameof(productManager));
    }

    [HttpPost]
    public async Task<ApiResponse<ReturnBlogPostDTO>> CreateBlogPostComment([FromBody] CreateBlogPostDto newProduct)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            return ApiResponse.Fail<ReturnBlogPostDTO>("Dados inválidos", errors);
        }

        try
        {
            var createdProduct = await _blogPostManager.CreateAsync(newProduct);
            return ApiResponse.Success(createdProduct, "Publicagem criada com sucesso");
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail<ReturnBlogPostDTO>("Houve um problema ao criar novo usuário.");
        }
    }
}