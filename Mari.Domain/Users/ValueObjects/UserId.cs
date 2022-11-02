using Mari.Domain.Common.Models;

namespace Mari.Domain.Users.ValueObjects;

public record UserId : ValueObjectWrapper<int>
{
    public static UserId Create(int value)
    {
        return new UserId(value);
    }

    public static UserId Default { get; } = new UserId(default(int));

    private UserId(int Value) : base(Value)
    {
    }
}
