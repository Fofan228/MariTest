using Mari.Client.Models.Releases;
using Mari.Contracts.Releases.Responce;

namespace Mari.Client.Common.Interfaces.Managers;

public interface IReleaseManager
{
    Task Create(ReleaseResponse release, CancellationToken token);
    void Get(Guid id);
    void GetCurrentReleases();
    void GetPlannedReleases();
    void GetInWorkReleases();
    void UpdateRelease();
    void DeleteRelease(string releaseId);
}
