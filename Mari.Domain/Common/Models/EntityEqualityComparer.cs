using System.Diagnostics.CodeAnalysis;

namespace Mari.Domain.Common.Models;

public class EntityEqualityComparer<TId> : IEqualityComparer<Entity<TId>>
    where TId : IEquatable<TId>
{
    public bool Equals(Entity<TId>? x, Entity<TId>? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null || y is null) return false;
        return x.Id.Equals(y.Id);
    }

    public int GetHashCode([DisallowNull] Entity<TId> entity)
    {
        return entity.Id.GetHashCode();
    }
}
