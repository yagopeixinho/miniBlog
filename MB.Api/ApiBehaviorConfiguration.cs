using Microsoft.AspNetCore.Mvc;

namespace MB.Api;
public static class ApiBehaviorConfiguration
{
    public static IServiceCollection ConfigureApiBehavior(this IServiceCollection services)
    {
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Type = "https://httpstatuses.com/400",
                    Title = "Validation Error",
                    Status = StatusCodes.Status400BadRequest,
                    Instance = context.HttpContext.Request.Path
                };

                return new BadRequestObjectResult(problemDetails)
                {
                    ContentTypes = { "application/problem+json" }
                };
            };
        });

        return services;
    }
}

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public string? Message { get; set; }
    public List<string>? Errors { get; set; }
}

public static class ApiResponse
{
    public static ApiResponse<T> Success<T>(T data, string? message = null) =>
        new ApiResponse<T> { Success = true, Data = data, Message = message };

    public static ApiResponse<T> Fail<T>(string message, List<string>? errors = null) =>
        new ApiResponse<T> { Success = false, Message = message, Errors = errors };
}