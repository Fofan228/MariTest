using Mari.Domain.Common.Models;

namespace Mari.Domain.Releases.ValueObjects;

public record ReleaseUpdateDate : ValueObjectWrapper<DateTime, ReleaseUpdateDate>
{
    [Obsolete(PublicConstructorObsoleteMessage, true)]
    public ReleaseUpdateDate() { }
}
