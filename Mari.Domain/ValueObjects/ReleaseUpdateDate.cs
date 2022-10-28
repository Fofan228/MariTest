using Mari.Domain.Common.Models;

namespace Mari.Domain.ValueObjects;

public record ReleaseUpdateDate : ValueObjectWrapper<DateTime>
{
    public static ReleaseUpdateDate Create(DateTime value)
    {
        return new ReleaseUpdateDate(value);
    }

    private ReleaseUpdateDate(DateTime Value) : base(Value)
    {
    }
}
