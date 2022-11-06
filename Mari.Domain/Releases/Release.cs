using ErrorOr;
using Mari.Domain.Common.Models;
using Mari.Domain.Releases.Entities;
using Mari.Domain.Releases.Enums;
using Mari.Domain.Releases.ValueObjects;

namespace Mari.Domain.Releases;

public class Release : AggregateRoot<ReleaseId>
{
    public static ErrorOr<Release> Create(
        Platform platform,
        ReleaseCompleteDate completeDate,
        ReleaseVersion? version = null,
        List<Issue>? issues = null,
        ReleaseId? id = null)
    {
        return new Release(
            id: id ?? ReleaseId.Default,
            platform: platform,
            completeDate: completeDate,
            updateDate: ReleaseUpdateDate.Create(completeDate.Value),
            status: ReleaseStatus.Planning,
            version: version ?? ReleaseVersion.MinValue,
            issues: issues ?? new List<Issue>()
        );
    }

    private Release() : base(default!)
    {
    }

    private Release(
        ReleaseId id,
        ReleaseVersion version,
        Platform platform,
        ReleaseCompleteDate completeDate,
        ReleaseUpdateDate updateDate,
        ReleaseStatus status,
        List<Issue> issues) : base(id)
    {
        Version = version;
        Platform = platform;
        Status = status;
        CompleteDate = completeDate;
        UpdateDate = updateDate;
        _issues = issues;
    }

    public ReleaseVersion Version { get; private set; } = null!;
    public Platform Platform { get; private set; } = null!;
    public ReleaseStatus Status { get; private set; }
    public ReleaseCompleteDate CompleteDate { get; private set; } = null!;
    public ReleaseUpdateDate UpdateDate { get; private set; } = null!;

    private List<Issue> _issues = new();
    public virtual IReadOnlyList<Issue> Issues => _issues;

    public ErrorOr<Created> AddIssue(Issue issue, ReleaseUpdateDate currentDateTime)
    {
        _issues.Add(issue);
        ChangeUpdateDate(currentDateTime);
        return Result.Created;
    }

    public ErrorOr<Deleted> RemoveIssue(Issue issue, ReleaseUpdateDate currentDateTime)
    {
        _issues.Remove(issue);
        ChangeUpdateDate(currentDateTime);
        return Result.Deleted;
    }

    public ErrorOr<Updated> ChangeVersion(ReleaseVersion version, ReleaseUpdateDate currentDateTime)
    {
        Version = version;
        ChangeUpdateDate(currentDateTime);
        return Result.Updated;
    }

    public ErrorOr<Updated> ChangePlatform(Platform platform, ReleaseUpdateDate currentDateTime)
    {
        Platform = platform;
        ChangeUpdateDate(currentDateTime);
        return Result.Updated;
    }

    public ErrorOr<Updated> ChangeStatus(ReleaseStatus status, ReleaseUpdateDate currentDateTime)
    {
        Status = status;
        ChangeUpdateDate(currentDateTime);
        return Result.Updated;
    }

    private void ChangeUpdateDate(ReleaseUpdateDate currentDateTime)
    {
        UpdateDate = currentDateTime;
    }
}
