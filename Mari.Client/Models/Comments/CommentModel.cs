namespace Mari.Client.Models.Comments;

public class CommentModel
{
    public Guid? CommentId { get; set; } = null!;
    public Guid? ReleaseId { get;  set; } = null!;
    public int UserId { get;  set; }
    public string UserName { get; set; } = null!;
    public DateTime? CreateDate { get; set; } = null!;
    public string Message { get; set; } = null!;
    public bool IsRedact { get; set; } = false;
}
