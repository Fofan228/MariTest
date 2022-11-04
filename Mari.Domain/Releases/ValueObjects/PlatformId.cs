using Mari.Domain.Common.Models;

namespace Mari.Domain.Releases.ValueObjects;

public record PlatformId : ValueObjectWrapper<int, PlatformId>
{
    [Obsolete(PublicConstructorObsoleteMessage, true)]
    public PlatformId() { }

    public static PlatformId Default { get; } = PlatformId.Create(default);
}
