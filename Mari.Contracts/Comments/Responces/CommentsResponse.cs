namespace Mari.Contracts.Comments.Responce;

public class CommentsResponse
{
    public CommentsResponse(IEnumerable<CommentResponse> comments)
    {
        Comments = comments.ToArray();
    }
    
    public CommentResponse[] Comments { get; set; }
}
