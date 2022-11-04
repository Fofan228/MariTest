using Mari.Domain.Common.Models;

namespace Mari.Domain.Users.ValueObjects;

public record UserId : ValueObjectWrapper<int, UserId>
{
    [Obsolete(PublicConstructorObsoleteMessage, true)]
    public UserId() { }

    public static UserId Default { get; } = UserId.Create(default);
}
