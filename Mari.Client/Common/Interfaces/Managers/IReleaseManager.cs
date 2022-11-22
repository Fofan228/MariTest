using Mari.Client.Models.Releases;

namespace Mari.Client.Common.Interfaces.Managers;

public interface IReleaseManager
{
    Task Create(NewReleaseFormModel request, CancellationToken token);
    void Get(Guid id);
    void GetCurrentReleases();
    void GetPlannedReleases();
    void GetInWorkReleases();
    void UpdateRelease();
    void DeleteRelease(string releaseId);
}
