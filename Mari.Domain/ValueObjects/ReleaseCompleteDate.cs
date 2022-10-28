using Mari.Domain.Common.Models;

namespace Mari.Domain.ValueObjects;

public record ReleaseCompleteDate : ValueObjectWrapper<DateTime>
{
    public static ReleaseCompleteDate Create(DateTime value)
    {
        return new ReleaseCompleteDate(value);
    }

    private ReleaseCompleteDate(DateTime Value) : base(Value)
    {
    }
}
