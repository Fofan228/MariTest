using Mari.Domain.Common.Models;
using Mari.Domain.ValueObjects;

namespace Mari.Domain.Entities;

public class Comment : AggregateRoot<Guid>
{
    public static Comment Create(
        UserId userId,
        Guid releaseId,
        CommentContent content)
    {
        return new Comment(
            id: default,
            userId: userId,
            releaseId: releaseId,
            content: content
        );
    }

    private Comment() : base(default)
    {
    }

    private Comment(
        Guid id,
        UserId userId,
        Guid releaseId,
        CommentContent content) : base(id)
    {
        UserId = userId;
        ReleaseId = releaseId;
        Content = content;
    }

    public CommentContent Content { get; private set; } = null!;
    public UserId UserId { get; private set; } = null!;
    public Guid ReleaseId { get; private set; }

    public void ChangeContent(CommentContent content)
    {
        Content = content;
    }
}
