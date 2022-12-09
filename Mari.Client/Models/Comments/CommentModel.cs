namespace Mari.Client.Models.Comments;

public class CommentModel
{
    public Guid CommentId { get; set; } 
    public Guid ReleaseId { get;  set; } 
    public int UserId { get;  set; }
    public string UserName { get; set; } = String.Empty;
    public string Content { get; set; } = String.Empty;
    public DateTime? CreateDate { get; set; } = null;
  
    public bool IsRedacted { get; set; } = false;
}
