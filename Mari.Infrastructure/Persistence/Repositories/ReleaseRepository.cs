using Mari.Application.Common.Interfaces.Persistence;
using Mari.Domain.Releases;
using Mari.Domain.Releases.ValueObjects;
using Mari.Infrastructure.Persistence.Shared;
using Microsoft.EntityFrameworkCore;

namespace Mari.Infrastructure.Persistence.Repositories;

public class ReleaseRepository : Repository<Release, ReleaseId>, IReleaseRepository
{
    public ReleaseRepository(MariDbContext context) : base(context)
    {
    }
}
