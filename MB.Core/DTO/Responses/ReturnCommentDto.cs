namespace MB.Manager.DTO.Requests;

public class ReturnCommentDTO
{
    public int Id { get; set; }
    public string Text { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public List<ReturnCommentDTO> Comments { get; set; } = new();
}
