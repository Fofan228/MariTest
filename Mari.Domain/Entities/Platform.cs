using Mari.Domain.Common.BaseClasses;
using Mari.Domain.ValueObjects;

namespace Mari.Domain.Entities;

public class Platform : EntityBase<int>
{
    public Platform()
    {
    }

    public Platform(int id, PlatformName name) : base(id)
    {
        Name = name;
    }

    public PlatformName Name { get; private set; } = null!;

    public void ChangeName(PlatformName name)
    {
        Name = name;
    }
}