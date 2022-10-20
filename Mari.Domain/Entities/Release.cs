using Mari.Domain.Common.BaseClasses;
using Mari.Domain.Enums;

namespace Mari.Domain.Entities;

public class Release : EntityBase<Guid>
{
    public Release()
    {
    }

    public Release(
        Guid id,
        Version version,
        Platform platform,
        ReleaseStatus status,
        DateTime completionDate,
        DateTime updationDate) : base(id)
    {
        Version = version;
        Platform = platform;
        Status = status;
        CompletionDate = completionDate;
        UpdationDate = updationDate;
    }

    public Version Version { get; private set; } = null!;
    public Platform Platform { get; private set; } = null!;
    public ReleaseStatus Status { get; private set; }
    public DateTime CompletionDate { get; private set; }
    public DateTime UpdationDate { get; private set; }

    private List<Issue> _issues = new();
    public IReadOnlyList<Issue> Issues => _issues;

    public void AddIssue(Issue issue, DateTime currentDateTime)
    {
        _issues.Add(issue);
        ChangeUpdationDate(currentDateTime);
    }

    public void ChangeVersion(Version version, DateTime currentDateTime)
    {
        Version = version;
        ChangeUpdationDate(currentDateTime);
    }

    public void ChangePlatform(Platform platform, DateTime currentDateTime)
    {
        Platform = platform;
        ChangeUpdationDate(currentDateTime);
    }

    public void ChangeStatus(ReleaseStatus status, DateTime currentDateTime)
    {
        Status = status;
        ChangeUpdationDate(currentDateTime);
    }

    private void ChangeUpdationDate(DateTime currentDateTime)
    {
        UpdationDate = currentDateTime;
    }
}