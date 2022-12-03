using Mari.Client.Models.Releases;
using Mari.Contracts.Releases.Responce;

namespace Mari.Client.Common.Interfaces.Managers;

public interface IReleaseManager
{
    Task Create(ReleaseCreateModel release, CancellationToken token = default);
    Task<ReleaseResponse> Get(Guid id,CancellationToken token = default);
    Task<IList<ReleaseResponse>> GetCurrentReleases(CancellationToken token = default);
    Task<IList<ReleaseResponse>> GetPlannedReleases(CancellationToken token = default);
    Task<IList<ReleaseResponse>> GetInWorkReleases(CancellationToken token = default);
    Task<IList<ReleaseResponse>> GetArchive(CancellationToken token = default);
    Task UpdateRelease(ReleaseResponse model,CancellationToken token = default);
    Task DeleteRelease(Guid id,CancellationToken token = default);
    
}
