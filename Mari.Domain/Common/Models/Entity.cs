using Mari.Domain.Common.Interfaces;

namespace Mari.Domain.Common.Models;

public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : IEquatable<TId>, IHasDefaultValue<TId>
{
    public TId Id { get; protected set; }

    protected Entity(TId? id)
    {
        Id = id ?? TId.Default;
    }

    public bool Equals(Entity<TId>? other)
    {
        if (ReferenceEquals(other, this)) return true;
        if (other is null) return false;
        return Id.Equals(other.Id);
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Entity<TId>);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override string ToString()
    {
        return $"[{GetType().Name} {Id}]";
    }

    public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
    {
        if (ReferenceEquals(left, right)) return true;
        return left?.Equals(right) ?? false;
    }

    public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
    {
        return !(left == right);
    }
}
