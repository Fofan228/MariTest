using Mari.Domain.Common.BaseClasses;
using Mari.Domain.ValueObjects;

namespace Mari.Domain.Entities;

public class Comment : EntityBase<Guid>
{
    private Comment()
    {
    }

    public Comment(CommentContent content, Guid releaseId, int userId)
    {
        Content = content;
        ReleaseId = releaseId;
        UserId = userId;
    }

    public CommentContent Content { get; private set; } = null!;
    public int UserId { get; init; }
    public Guid ReleaseId { get; init; }

    public void ChangeContent(CommentContent content)
    {
        Content = content;
    }

    public static Comment Create(int userId, Guid releaseId, CommentContent content) => new Comment
    {
        Content = content,
        ReleaseId = releaseId,
        UserId = userId
    };
}
