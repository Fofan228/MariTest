using Mari.Domain.Common.BaseClasses;

namespace Mari.Domain.ValueObjects;

public record IssueTitle(string Value) : ValueObjectBase
{
    //TODO Переделать регулярку, если надо
    public const string Pattern = @"^[^\d\W]+.*";
    public static implicit operator string(IssueTitle value) => value.ToString();
    public override string ToString() => Value;
}
