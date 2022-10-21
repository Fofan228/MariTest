using Mari.Domain.Common.BaseClasses;
using Mari.Domain.Enums;
using Mari.Domain.ValueObjects;

namespace Mari.Domain.Entities;

public class Release : EntityBase<Guid>
{
    public Release()
    {
    }

    public Release(
        Guid id,
        Platform platform,
        ReleaseStatus status, // TODO Должен ли быть статус по умолчанию?
        DateTime completionDate,
        DateTime currentDate,
        ReleaseVersion? version = null) : base(id)
    {
        Platform = platform;
        Status = status;
        CompletionDate = completionDate;
        UpdationDate = currentDate;
        Version = version ?? ReleaseVersion.MinValue;
    }

    public ReleaseVersion Version { get; private set; } = null!;
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

    public void ChangeVersion(ReleaseVersion version, DateTime currentDateTime)
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