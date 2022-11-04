using Mari.Domain.Common.Models;

namespace Mari.Domain.Releases.ValueObjects;

public record ReleaseId : ValueObjectWrapper<Guid, ReleaseId>
{
    [Obsolete(PublicConstructorObsoleteMessage, true)]
    public ReleaseId() { }

    public static ReleaseId Default { get; } = ReleaseId.Create(default);
}
