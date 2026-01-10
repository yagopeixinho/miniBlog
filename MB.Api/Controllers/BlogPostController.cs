using MB.Manager.DTO.Requests;
using MB.Manager.DTO.Responses;
using MB.Manager.Interfaces.Manager;
using Microsoft.AspNetCore.Mvc;

namespace MB.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogPostController : ApiControllerBase
{
    private readonly IBlogPostManager _blogPostManager;

    public BlogPostController(IBlogPostManager productManager)
    {
        _blogPostManager = productManager ?? throw new ArgumentNullException(nameof(productManager));
    }

    [HttpGet]
    public async Task<ApiResponse<ReturnBlogPostDTO[]>> GetAllPosts()
    {
        var user = await _blogPostManager.GetAllPosts();
        return user is not null
            ? ApiResponse.Success(user)
            : ApiResponse.Fail<ReturnBlogPostDTO[]>("Usuário não encontrado");
    }


    [HttpGet("{id:int}")]
    public async Task<ApiResponse<ReturnBlogPostDTO>> GetByIdAsync(int id)
    {
        var user = await _blogPostManager.GetByIdAsync(id);
        return user is not null
            ? ApiResponse.Success(user)
            : ApiResponse.Fail<ReturnBlogPostDTO>("Usuário não encontrado");
    }

    [HttpPost]
    public async Task<ApiResponse<ReturnBlogPostDTO>> CreateBlogPostAsync([FromBody] CreateBlogPostDto newProduct)
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