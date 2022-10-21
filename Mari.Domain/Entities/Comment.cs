using Mari.Domain.Common.BaseClasses;
using Mari.Domain.ValueObjects;

namespace Mari.Domain.Entities;

public class Comment : EntityBase<Guid>
{
    public Comment()
    {
    }

    public Comment(Guid id, CommentContent content, Guid releaseId, int userId) : base(id)
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
}