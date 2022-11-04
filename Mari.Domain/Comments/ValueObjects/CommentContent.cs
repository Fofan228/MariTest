using Mari.Domain.Common.Models;

namespace Mari.Domain.Comments.ValueObjects;

public record CommentContent : ValueObjectWrapper<string, CommentContent>
{
    [Obsolete(PublicConstructorObsoleteMessage, true)]
    public CommentContent() { }

    public const string Pattern = @".+";
    public const int MaxLength = 1000;
}
