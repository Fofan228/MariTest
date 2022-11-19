using Mari.Domain.Common.Interfaces;
using Mari.Domain.Common.Models;

namespace Mari.Domain.Users.ValueObjects;

public record Username : ValueObjectWrapper<string, Username>, IStringWrapper
{
    [Obsolete(PublicConstructorObsoleteMessage, true)]
    public Username() { }

    public static string Pattern => @"^[^\d\W]+.*";
    public static uint? MaxLength => 30;
    public static uint? MinLength => 4;

    public override void OnCreate(ref string value)
    {
        if (value.Length > MaxLength)
            value = value.Substring(0, ((int)MaxLength));
    }
}
