using Mari.Domain.Common.Models;
using Mari.Domain.Releases.ValueObjects;

namespace Mari.Domain.Releases.Entities;

public class Platform : Entity<PlatformId>
{
    public static Platform Create(PlatformName name, PlatformId? id = null)
    {
        return new Platform(
            id: id ?? PlatformId.Default,
            name: name
        );
    }

    private Platform() : base(default!)
    {
    }

    private Platform(PlatformId id, PlatformName name) : base(id)
    {
        Name = name;
    }

    public PlatformName Name { get; private set; } = null!;

    public void ChangeName(PlatformName name)
    {
        Name = name;
    }
}
