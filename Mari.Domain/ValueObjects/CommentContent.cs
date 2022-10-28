using Mari.Domain.Common.Models;

namespace Mari.Domain.ValueObjects;

public record CommentContent : ValueObjectWrapper<string>
{
    public const string Pattern = @".+";
    public const int MaxLength = 1000;

    public static CommentContent Create(string value)
    {
        return new CommentContent(value);
    }

    private CommentContent(string value) : base(value)
    {
    }
}
