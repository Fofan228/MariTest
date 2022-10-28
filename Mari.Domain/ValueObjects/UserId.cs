using Mari.Domain.Common.Models;

namespace Mari.Domain.ValueObjects;

public record UserId : ValueObjectWrapper<int>
{
    public static UserId Create(int value)
    {
        return new UserId(value);
    }

    private UserId(int Value) : base(Value)
    {
    }
}
