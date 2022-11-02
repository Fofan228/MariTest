using Mari.Domain.Common.Models;

namespace Mari.Domain.Releases.ValueObjects;

public record ReleaseId : ValueObjectWrapper<Guid>
{
    public static ReleaseId Create(Guid value)
    {
        return new ReleaseId(value);
    }

    public static ReleaseId Default { get; } = new ReleaseId(default(Guid));

    private ReleaseId(Guid Value) : base(Value)
    {
    }
}
