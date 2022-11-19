using Mari.Domain.Common.Models;

namespace Mari.Domain.Comments.ValueObjects;

public record CommentCreateDate : ValueObjectWrapper<DateTime, CommentCreateDate>
{
    [Obsolete(PublicConstructorObsoleteMessage, true)]
    public CommentCreateDate() { }
}
