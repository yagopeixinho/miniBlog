using MB.Core.DTO.Requests;
using MB.Manager.DTO.Requests;

namespace MB.Core.Interfaces.Manager;

public interface IBlogPostCommentManager
{
    Task<ReturnCommentDTO> CreateAsync(
        int postId,
        ReturnCommentDto request);
}