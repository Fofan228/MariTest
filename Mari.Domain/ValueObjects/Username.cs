using Mari.Domain.Common.BaseClasses;

namespace Mari.Domain.ValueObjects;

public record Username(string Value) : ValueObjectBase
{
    public static implicit operator Username(string value) => new(value);
    public static implicit operator string(Username value) => value.Value;
}