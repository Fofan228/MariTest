using Mari.Domain.Releases;

namespace Mari.Application.Releases.Results;

public record ReleaseResult(
    string version,
    string platformName,
    string status,
    DateTime completeDate,
    DateTime updateDate,
    string mainIssue,
    string description)
{
    public static ReleaseResult FromRelease(Release release) => new(
        version: release.Version.ToVersionString(),
        platformName: release.Platform.Name,
        status: release.Status.ToString(),
        completeDate: release.CompleteDate,
        updateDate: release.UpdateDate,
        mainIssue: release.MainIssue,
        description: release.Description);
}
