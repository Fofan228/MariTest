using Mari.Domain.Releases;

namespace Mari.Application.Releases.Results;

public record ReleaseResult(
    Guid Id,
    string Version,
    string PlatformName,
    string Status,
    DateTime CompleteDate,
    DateTime UpdateDate,
    string MainIssue,
    string Description)
{
    public static ReleaseResult FromRelease(Release release) => new(
        Id: release.Id,
        Version: release.Version.ToVersionString(),
        PlatformName: release.Platform.Name,
        Status: release.Status.ToString(),
        CompleteDate: release.CompleteDate,
        UpdateDate: release.UpdateDate,
        MainIssue: release.MainIssue,
        Description: release.Description);
}
