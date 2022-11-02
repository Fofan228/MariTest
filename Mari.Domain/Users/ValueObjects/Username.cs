using Mari.Domain.Common.Models;

namespace Mari.Domain.Users.ValueObjects;

public record Username : ValueObjectWrapper<string>
{
    public const string Pattern = @"^[^\d\W]+.*";

    public static Username Create(string value)
    {
        return new Username(value);
    }

    private Username(string Value) : base(Value)
    {
    }
}
