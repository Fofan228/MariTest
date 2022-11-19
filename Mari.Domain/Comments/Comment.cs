using ErrorOr;
using Mari.Domain.Comments.ValueObjects;
using Mari.Domain.Common.Models;
using Mari.Domain.Releases.ValueObjects;
using Mari.Domain.Users.ValueObjects;
using Mari.Domain.Common.Errors;
using Mari.Domain.Comments.Enums;

namespace Mari.Domain.Comments;

public class Comment : AggregateRoot<CommentId>
{
    public static ErrorOr<Comment> Create(
        UserId userId,
        ReleaseId releaseId,
        CommentContent content,
        CommentCreateDate createDate,
        bool isSystem = false,
        CommentId? id = null)
    {
        return new Comment(
            id: id ?? CommentId.Default,
            userId: userId,
            releaseId: releaseId,
            content: content,
            createDate: createDate,
            isSystem: isSystem);
    }

    private Comment() : base(default!)
    {
    }

    private Comment(
        CommentId id,
        UserId userId,
        ReleaseId releaseId,
        CommentContent content,
        CommentCreateDate createDate,
        bool isSystem) : base(id)
    {
        UserId = userId;
        ReleaseId = releaseId;
        Content = content;
        CreateDate = createDate;
        IsSystem = isSystem;
        IsRedacted = false;
    }

    public static Comment CreateSystemComment(
        UserId userId,
        ReleaseId releaseId,
        SystemAction action,
        CommentCreateDate createDate,
        string? additionalInfo = null,
        CommentId? id = null)
    {
        additionalInfo = string.IsNullOrWhiteSpace(additionalInfo)
            ? string.Empty
            : $"\n{additionalInfo}";

        return new Comment(
            id: id ?? CommentId.Default,
            userId: userId,
            releaseId: releaseId,
            content: CommentContent.Create($"Действие: {action}{additionalInfo}"),
            createDate: createDate,
            isSystem: true);
    }

    public CommentContent Content { get; private set; } = null!;
    public UserId UserId { get; private set; } = null!;
    public ReleaseId ReleaseId { get; private set; } = null!;
    public CommentCreateDate CreateDate { get; private set; } = null!;
    public bool IsRedacted { get; private set; }
    public bool IsSystem { get; private set; }

    public ErrorOr<Updated> ChangeContent(CommentContent content)
    {
        if (IsSystem) return Errors.Comment.BlockedBySystem;
        IsRedacted = true;
        Content = content;
        return Result.Updated;
    }
}
