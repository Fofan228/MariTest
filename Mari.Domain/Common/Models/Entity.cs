namespace Mari.Domain.Common.Models;

public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : IEquatable<TId>
{
    public static EntityEqualityComparer<TId> EqualityComparer { get; } = new EntityEqualityComparer<TId>();

    public TId Id { get; protected set; }

    protected Entity(TId id)
    {
        Id = id;
    }

    public bool Equals(Entity<TId>? other)
    {
        return EqualityComparer.Equals(this, other);
    }

    public override bool Equals(object? obj)
    {
        return EqualityComparer.Equals(this, obj as Entity<TId>);
    }

    public override int GetHashCode()
    {
        return EqualityComparer.GetHashCode(this);
    }

    public override string ToString()
    {
        return $"[{GetType().Name} {Id}]";
    }

    public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
    {
        return EqualityComparer.Equals(left, right);
    }

    public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
    {
        return !EqualityComparer.Equals(left, right);
    }
}
