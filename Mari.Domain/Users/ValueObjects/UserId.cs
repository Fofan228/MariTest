using Mari.Domain.Common.Interfaces;
using Mari.Domain.Common.Models;

namespace Mari.Domain.Users.ValueObjects;

public record UserId : ValueObjectWrapper<int, UserId>, IHasDefaultValue<UserId>
{
    [Obsolete(PublicConstructorObsoleteMessage, true)]
    public UserId() { }

    public static UserId Default { get; } = UserId.Create(default);
}
