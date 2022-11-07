using Mari.Application.Common.Interfaces.Persistence.Shared;
using Mari.Domain.Releases;
using Mari.Domain.Releases.ValueObjects;

namespace Mari.Application.Common.Interfaces.Persistence;

public interface IReleaseRepository : IRepository<Release, ReleaseId>
{

}
