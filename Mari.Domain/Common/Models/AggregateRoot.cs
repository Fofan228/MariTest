namespace Mari.Domain.Common.Models;

public abstract class AggregateRoot<TId> : Entity<TId>
    where TId : IEquatable<TId>
{
    protected AggregateRoot(TId id) : base(id)
    {
    }
}
