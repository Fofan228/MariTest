namespace Mari.Domain.Common.Interfaces;

public interface IEntity<TId> : IEquatable<IEntity<TId>>
    where TId : IEquatable<TId>
{
    TId Id { get; }
}