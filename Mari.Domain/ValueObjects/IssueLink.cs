using Mari.Domain.Common.BaseClasses;

namespace Mari.Domain.ValueObjects;

public record IssueLink(string Value) : ValueObjectBase
{
    public static implicit operator string(IssueLink value) => value.Value;
}