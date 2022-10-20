using Mari.Domain.Common.BaseClasses;

namespace Mari.Domain.ValueObjects;

public record IssueTitle(string Value) : ValueObjectBase
{
    public static implicit operator string(IssueTitle value) => value.Value;
}