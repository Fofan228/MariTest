using Mari.Domain.Common.BaseClasses;
using Mari.Domain.ValueObjects;

namespace Mari.Domain.Entities;

public class Platform : EntityBase<int>
{
    private Platform()
    {
    }

    public PlatformName Name { get; private set; } = null!;

    public void ChangeName(PlatformName name)
    {
        Name = name;
    }

    public static Platform Create(PlatformName name) => new Platform
    {
        Name = name
    };
}
