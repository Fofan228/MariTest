namespace Mari.Contracts.Comments.Responce;

public class CommentAllResponse
{
    public CommentAllResponse(IEnumerable<CommentResponse> comments)
    {
        Comments = comments.ToArray();
    }
    
    public CommentResponse[] Comments { get; set; }
}
