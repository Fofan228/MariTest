namespace Mari.Contracts.Comments.Responses;

public class CommentResponse 
{
    public CommentResponse(Guid? commentId, Guid? releaseId, int? userId, 
        string userName, string message, string createDate, bool isEdit)
    {
        CommentId = commentId;
        ReleaseId = releaseId;
        UserId = userId;
        UserName = userName;
        Message = message;
        CreateDate = createDate;
        IsEdit = isEdit;
    }

    public Guid? CommentId { get;  set; } = null!;
    public Guid? ReleaseId { get;  set; } = null!;
    public int? UserId { get;  set; } = null!;
    public string UserName { get; set; } = null!;
    public string Message { get; set; } = null!;
    public string CreateDate { get;  set; } = null!;
    public bool IsEdit { get;  set; } = false; 

}
