using Mari.Client.Models.Releases;
using Mari.Contracts.Releases.Responses;

namespace Mari.Client.Common.Interfaces.Managers;

public interface IReleaseManager
{
    Task Create(ReleaseCreateModel release, CancellationToken token = default);
    Task<ReleaseModel> Get(Guid id,CancellationToken token = default);
    Task<IList<ReleaseModel>> GetCurrentReleases(CancellationToken token = default);
    Task<IList<ReleaseModel>> GetPlannedReleases(CancellationToken token = default);
    Task<IList<ReleaseModel>> GetInWorkReleases(CancellationToken token = default);
    Task<IList<ReleaseModel>> GetArchive(CancellationToken token = default);
    Task UpdateRelease(ReleaseModel model,CancellationToken token = default);
    Task DeleteRelease(Guid id,CancellationToken token = default);
    Task<IList<PlatformResponse>> GetAllPlatforms(CancellationToken token = default);
    
}
