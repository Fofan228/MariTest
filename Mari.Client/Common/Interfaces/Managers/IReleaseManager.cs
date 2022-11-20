using Mari.Contracts.Releases;

namespace Mari.Client.Common.Interfaces.Managers;

public interface IReleaseManager
{
    Task Create(ReleaseCreateRequest request, CancellationToken token);
    void Get(Guid id);
    void GetCurrentReleases();
    void GetPlannedReleases();
    void GetInWorkReleases();
    void UpdateRelease();
    void DeleteRelease(string releaseId);
}
