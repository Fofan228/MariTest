using Mari.Domain.Comments.ValueObjects;
using Mari.Domain.Common.Models;
using Mari.Domain.Releases.ValueObjects;
using Mari.Domain.Users.ValueObjects;

namespace Mari.Domain.Comments;

public class Comment : AggregateRoot<CommentId>
{
    public static Comment Create(
        UserId userId,
        ReleaseId releaseId,
        CommentContent content)
    {
        return new Comment(
            id: CommentId.Create(default),
            userId: userId,
            releaseId: releaseId,
            content: content
        );
    }

    private Comment() : base(default!)
    {
    }

    private Comment(
        CommentId id,
        UserId userId,
        ReleaseId releaseId,
        CommentContent content) : base(id)
    {
        UserId = userId;
        ReleaseId = releaseId;
        Content = content;
    }

    public CommentContent Content { get; private set; } = null!;
    public UserId UserId { get; private set; } = null!;
    public ReleaseId ReleaseId { get; private set; } = null!;

    public void ChangeContent(CommentContent content)
    {
        Content = content;
    }
}
