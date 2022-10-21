using Mari.Domain.Common.BaseClasses;

namespace Mari.Domain.ValueObjects;

public record IssueLink(string Value) : ValueObjectBase
{
    //TODO Переделать регулярку, если надо
    public const string Pattern = @"^[^\d\W]+.*";
    public static implicit operator string(IssueLink value) => value.ToString();
    public override string ToString() => Value;
}