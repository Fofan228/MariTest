using Mari.Domain.Common.Interfaces;

namespace Mari.Domain.Common.BaseClasses;

public abstract class EntityBase<TId> : IEntity<TId>
    where TId : IEquatable<TId>
{
    public TId Id { get; set; } = default(TId)!;

    protected EntityBase(TId id)
    {
        Id = id;
    }

    protected EntityBase() { }

    public bool Equals(IEntity<TId>? other)
    {
        if (ReferenceEquals(this, other)) return true;
        if (other is not IEntity<TId> otherEntity) return false;
        return Id.Equals(other.Id);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not IEntity<TId> entity) return false;
        return Equals(entity);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }

    public static bool operator ==(EntityBase<TId> entity1, EntityBase<TId> entity2)
    {
        return entity1.Equals(entity2);
    }

    public static bool operator !=(EntityBase<TId> entity1, EntityBase<TId> entity2)
    {
        return !entity1.Equals(entity2);
    }
}