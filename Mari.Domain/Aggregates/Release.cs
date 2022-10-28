using System.Collections.Generic;
using Mari.Domain.Common.Models;
using Mari.Domain.Enums;
using Mari.Domain.ValueObjects;

namespace Mari.Domain.Entities;

public class Release : AggregateRoot<Guid>
{
    public static Release Create(
        Guid id,
        Platform platform,
        ReleaseCompleteDate completeDate,
        ReleaseStatus status = ReleaseStatus.Planning,
        ReleaseVersion? version = null,
        List<Issue>? issues = null)
    {
        return new Release(
            id: id,
            platform: platform,
            completeDate: completeDate,
            updateDate: ReleaseUpdateDate.Create(completeDate.Value),
            status: status,
            version: version ?? ReleaseVersion.MinValue,
            issues: issues ?? new List<Issue>()
        );
    }

    private Release() : base(default)
    {
    }

    public Release(
        Guid id,
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

    public void AddIssue(Issue issue, ReleaseUpdateDate currentDateTime)
    {
        _issues.Add(issue);
        ChangeUpdateDate(currentDateTime);
    }

    public void RemoveIssue(Issue issue, ReleaseUpdateDate currentDateTime)
    {
        _issues.Remove(issue);
        ChangeUpdateDate(currentDateTime);
    }

    public void ChangeVersion(ReleaseVersion version, ReleaseUpdateDate currentDateTime)
    {
        Version = version;
        ChangeUpdateDate(currentDateTime);
    }

    public void ChangePlatform(Platform platform, ReleaseUpdateDate currentDateTime)
    {
        Platform = platform;
        ChangeUpdateDate(currentDateTime);
    }

    public void ChangeStatus(ReleaseStatus status, ReleaseUpdateDate currentDateTime)
    {
        Status = status;
        ChangeUpdateDate(currentDateTime);
    }

    private void ChangeUpdateDate(ReleaseUpdateDate currentDateTime)
    {
        UpdateDate = currentDateTime;
    }
}
