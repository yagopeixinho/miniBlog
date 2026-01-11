using MB.Manager.DTO.Requests;
using MB.Manager.DTO.Responses;

namespace MB.Manager.Interfaces.Manager;

public interface IBlogPostCommentManager
{
    Task<ReturnCommentDTO> CreateAsync(
        int postId,
        ReturnCommentDto request);


}