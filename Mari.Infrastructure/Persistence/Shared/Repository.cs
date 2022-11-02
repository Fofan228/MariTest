using LinqSpecs;
using Mari.Application.Common.Interfaces.Persistence.Shared;
using Mari.Domain.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Mari.Infrastructure.Persistence.Shared;

public abstract class Repository<TAggregateRoot, TId> : IRepository<TAggregateRoot, TId>
    where TAggregateRoot : AggregateRoot<TId>
    where TId : IEquatable<TId>
{
    protected readonly DbContext Context;
    protected readonly DbSet<TAggregateRoot> Set;

    protected Repository(DbContext context)
    {
        Context = context;
        Set = context.Set<TAggregateRoot>();
    }

    public virtual async Task<TAggregateRoot?> GetById(TId id, CancellationToken token = default)
    {
        return await Set.FirstOrDefaultAsync(x => x.Id.Equals(id), token);
    }

    public async Task<IList<TAggregateRoot>> GetById(IEnumerable<TId> ids, CancellationToken token = default)
    {
        ids = ids.ToList();
        return await Set.Where(x => ids.Contains(x.Id)).ToListAsync(token);
    }

    public virtual async Task<TAggregateRoot?> Find(Specification<TAggregateRoot> specification, CancellationToken token = default)
    {
        return await Set.FirstOrDefaultAsync(specification, token);
    }

    public virtual async Task<IList<TAggregateRoot>> FindMany(Specification<TAggregateRoot>? specification = null, Range range = default, CancellationToken token = default)
    {
        var query = Set.Where(specification ?? new TrueSpecification<TAggregateRoot>());
        query = await AddRange(query, range, token, specification);
        return await query.ToListAsync(token);
    }

    public virtual IAsyncEnumerable<TAggregateRoot> List(Specification<TAggregateRoot>? specification = null)
    {
        var query = Set.Where(specification ?? new TrueSpecification<TAggregateRoot>());
        return query.AsAsyncEnumerable();
    }

    public virtual IAsyncEnumerable<TAggregateRoot> ListById(IEnumerable<TId> ids)
    {
        ids = ids.ToList();
        return Set.Where(x => ids.Contains(x.Id)).AsAsyncEnumerable();
    }

    public virtual Task<TAggregateRoot> Insert(TAggregateRoot aggregateRoot, CancellationToken token = default)
    {
        Set.AddAsync(aggregateRoot, token);
        return Task.FromResult(aggregateRoot);
    }

    public virtual Task<TAggregateRoot> Update(TAggregateRoot aggregateRoot, CancellationToken token = default)
    {
        if (token.IsCancellationRequested) return Task.FromCanceled<TAggregateRoot>(token);
        Set.Update(aggregateRoot);
        return Task.FromResult(aggregateRoot);
    }

    public Task Delete(TAggregateRoot aggregateRoot, CancellationToken token = default)
    {
        if (token.IsCancellationRequested) return Task.FromCanceled(token);
        Set.Remove(aggregateRoot);
        return Task.CompletedTask;
    }

    public async Task DeleteById(TId id, CancellationToken token = default)
    {
        var aggregateRoot = await Set.FirstOrDefaultAsync(x => x.Id.Equals(id), token);
        if (aggregateRoot is not null) Set.Remove(aggregateRoot);
    }

    public async Task<bool> Exists(TId id, CancellationToken token = default)
    {
        return await Set.AnyAsync(x => x.Id.Equals(id), token);
    }

    public virtual Task<bool> Exists(Specification<TAggregateRoot>? specification = null, CancellationToken token = default)
    {
        return Set.AnyAsync(specification ?? new TrueSpecification<TAggregateRoot>(), token);
    }

    public virtual async Task<int> Count(Specification<TAggregateRoot>? specification = null, CancellationToken token = default)
    {
        return await Set.CountAsync(specification ?? new TrueSpecification<TAggregateRoot>(), token);
    }

    protected async Task<IQueryable<TAggregateRoot>> AddRange(
        IQueryable<TAggregateRoot> query,
        Range range,
        CancellationToken token,
        Specification<TAggregateRoot>? specification = null)
    {
        if (range.Start.Value > range.End.Value)
        {
            throw new ArgumentOutOfRangeException(
                nameof(range),
                $"{nameof(range.Start)} must be less than or equal to {nameof(range.End)}.");
        }

        if (range.Equals(default))
        {
            return query;
        }

        if (range.Start.IsFromEnd || range.End.IsFromEnd)
        {
            var count = await Set.CountAsync(specification ?? new TrueSpecification<TAggregateRoot>(), token);
            (var offset, var length) = range.GetOffsetAndLength(count);
            return query.Skip(offset).Take(length);
        }

        return query.Skip(range.Start.Value)
            .Take(range.End.Value - range.Start.Value);
    }
}
