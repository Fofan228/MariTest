using Mari.Domain.Common.BaseClasses;
using Mari.Domain.Enums;
using Mari.Domain.ValueObjects;

namespace Mari.Domain.Entities;

public class Release : EntityBase<Guid>
{
    private Release()
    {
    }

    public ReleaseVersion Version { get; private set; } = null!;
    public Platform Platform { get; private set; } = null!;
    public ReleaseStatus Status { get; private set; }
    public DateTime CompleteDate { get; private set; }
    public DateTime UpdateDate { get; private set; }

    private List<Issue> _issues = new();
    public virtual IReadOnlyList<Issue> Issues => _issues;

    public void AddIssue(Issue issue, DateTime currentDateTime)
    {
        _issues.Add(issue);
        ChangeUpdateDate(currentDateTime);
    }

    public void ChangeVersion(ReleaseVersion version, DateTime currentDateTime)
    {
        Version = version;
        ChangeUpdateDate(currentDateTime);
    }

    public void ChangePlatform(Platform platform, DateTime currentDateTime)
    {
        Platform = platform;
        ChangeUpdateDate(currentDateTime);
    }

    public void ChangeStatus(ReleaseStatus status, DateTime currentDateTime)
    {
        Status = status;
        ChangeUpdateDate(currentDateTime);
    }

    private void ChangeUpdateDate(DateTime currentDateTime)
    {
        UpdateDate = currentDateTime;
    }

    public static Release Create(
        Platform platform,
        ReleaseStatus status, // TODO Должен ли быть статус по умолчанию?
        DateTime completeDate,
        DateTime currentDate,
        ReleaseVersion? version = null) => new Release
        {
            Platform = platform,
            Status = status,
            CompleteDate = completeDate,
            UpdateDate = currentDate,
            Version = version ?? ReleaseVersion.MinValue
        };
}
