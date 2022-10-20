using Mari.Domain.Common.BaseClasses;

namespace Mari.Domain.ValueObjects;

public record PlatformName(string Value) : ValueObjectBase
{
    public static implicit operator string(PlatformName value) => value.Value;
}