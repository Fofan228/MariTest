using Mari.Domain.Common.BaseClasses;

namespace Mari.Domain.ValueObjects;

public record CommentContent(string Value) : ValueObjectBase
{
    public const string Pattern = @".+";
    public const int MaxLength = 1000;

    public static implicit operator string(CommentContent content) => content.ToString();
    public override string ToString() => Value;
}