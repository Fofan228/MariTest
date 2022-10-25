using Mari.Domain.Common.BaseClasses;

namespace Mari.Domain.ValueObjects;

public record Username(string Value) : ValueObjectBase
{
    public static implicit operator string(Username value) => value.ToString();
    public override string ToString() => Value;
}
