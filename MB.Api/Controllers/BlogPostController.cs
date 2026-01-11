using MB.Api.Configuration;
using MB.Core.DTO.Responses;
using MB.Core.Interfaces.Manager;
using MB.Manager.DTO.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MB.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogPostController(IBlogPostManager blogPostManager) : ApiControllerBase
{
    private readonly IBlogPostManager _blogPostManager = blogPostManager ?? throw new ArgumentNullException(nameof(blogPostManager));

    [HttpGet]
    public async Task<ApiResponse<List<ReturnBlogPostListDTO>>> GetAllPosts()
    {
        var posts = await _blogPostManager.GetAllPosts();
        return posts is not null
            ? ApiResponse.Success(posts)
            : ApiResponse.Fail<List<ReturnBlogPostListDTO>>("Nenhum post encontrado");
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<ReturnBlogPostDTO>> GetByIdAsync(int id)
    {
        var post = await _blogPostManager.GetByIdAsync(id);
        return post is not null
            ? ApiResponse.Success(post)
            : ApiResponse.Fail<ReturnBlogPostDTO>("Post não encontrado");
    }

    [HttpPost]
    public async Task<ApiResponse<ReturnBlogPostDTO>> CreateBlogPostAsync([FromBody] CreateBlogPostDto newPost)
    {
        if (!ModelState.IsValid)
        {
            return ApiResponse.Fail<ReturnBlogPostDTO>(
                "Dados inválidos",
                [.. ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)]
            );
        }

        try
        {
            var createdPost = await _blogPostManager.CreateAsync(newPost);
            return ApiResponse.Success(createdPost, "Post criado com sucesso");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);

            return ApiResponse.Fail<ReturnBlogPostDTO>(
                "Houve um problema ao criar o post. Tente novamente mais tarde."
            );
        }
    }
}
