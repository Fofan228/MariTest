
namespace Mari.Client.Models.Comments;

public class CommentCreateModel
{

    public Guid? ReleaseId { get;  set; } = null!;
    public int UserId { get;  set; }
    public string Message { get; set; } = null!;


}
