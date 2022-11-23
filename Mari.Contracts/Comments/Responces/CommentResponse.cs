namespace Mari.Contracts.Comments.Responce;

public class CommentResponse 
{
    public CommentResponse(string commentId, string userId, string userName, string message, string createDate, bool isEdit)
    {
        CommentId = commentId;
        UserId = userId;
        UserName = userName;
        Message = message;
        CreateDate = createDate;
        IsEdit = isEdit;
    }

    public string CommentId { get; private set; } = null!;
    public string UserId { get; private set; } = null!;
    public string UserName { get;private set; } = null!;
    public string Message { get;private set; } = null!;
    public string CreateDate { get; private set; } = null!;
    public bool IsEdit { get; private set; } = false; 

}
