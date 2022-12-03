using Mari.Client.Models.Releases;
using Mari.Contracts.Releases.Responce;

namespace Mari.Client.Common.Interfaces.Managers;

public interface IReleaseManager
{
    Task Create(ReleaseCreateModel release, CancellationToken token);
    Task<ReleaseResponse> Get(Guid id,CancellationToken token);
    Task<IEnumerable<ReleaseResponse>> GetCurrentReleases(CancellationToken token);
    Task<IEnumerable<ReleaseResponse>> GetPlannedReleases(CancellationToken token);
    Task<IEnumerable<ReleaseResponse>> GetInWorkReleases(CancellationToken token);
    Task UpdateRelease(ReleaseResponse model,CancellationToken token);
    Task DeleteRelease(Guid id,CancellationToken token);
    
    Task<IEnumerable<ReleaseResponse>> Test();
}
