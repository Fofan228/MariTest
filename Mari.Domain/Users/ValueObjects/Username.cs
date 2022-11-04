using Mari.Domain.Common.Models;

namespace Mari.Domain.Users.ValueObjects;

public record Username : ValueObjectWrapper<string, Username>
{
    [Obsolete(PublicConstructorObsoleteMessage, true)]
    public Username() { }

    public const string Pattern = @"^[^\d\W]+.*";
    public const int MaxLength = 30;

    public override void OnCreate(ref string value)
    {
        if (value.Length > MaxLength)
            value = value.Substring(0, MaxLength);
    }
}
