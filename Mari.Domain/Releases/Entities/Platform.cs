using Mari.Domain.Common.Models;
using Mari.Domain.Releases.ValueObjects;

namespace Mari.Domain.Releases.Entities;

public class Platform : Entity<int>
{
    public static Platform Create(PlatformName name) => new Platform(
        id: default,
        name: name
    );

    private Platform() : base(default)
    {
    }

    private Platform(int id, PlatformName name) : base(id)
    {
        Name = name;
    }

    public PlatformName Name { get; private set; } = null!;

    public void ChangeName(PlatformName name)
    {
        Name = name;
    }
}
