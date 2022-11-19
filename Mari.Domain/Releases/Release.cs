using ErrorOr;
using Mari.Domain.Common.Models;
using Mari.Domain.Releases.Entities;
using Mari.Domain.Releases.Enums;
using Mari.Domain.Releases.ValueObjects;
using Mari.Domain.Common.Errors;

namespace Mari.Domain.Releases;

public class Release : AggregateRoot<ReleaseId>
{
    public static ErrorOr<Release> Create(
        Issue mainIssue,
        Platform platform,
        ReleaseCompleteDate completeDate,
        ReleaseDescription? description = null,
        ReleaseVersion? version = null,
        ReleaseId? id = null)
    {
        return new Release(
            id: id ?? ReleaseId.Default,
            mainIssue: mainIssue,
            platform: platform,
            completeDate: completeDate,
            updateDate: ReleaseUpdateDate.Create(completeDate.Value),
            status: ReleaseStatus.Planning,
            description: description ?? ReleaseDescription.Default,
            version: version ?? ReleaseVersion.MinValue
        );
    }

    private Release() : base(default!)
    {
    }

    private Release(
        ReleaseId id,
        Issue mainIssue,
        ReleaseVersion version,
        Platform platform,
        ReleaseCompleteDate completeDate,
        ReleaseUpdateDate updateDate,
        ReleaseStatus status,
        ReleaseDescription description) : base(id)
    {
        Version = version;
        Platform = platform;
        Status = status;
        CompleteDate = completeDate;
        UpdateDate = updateDate;
        MainIssue = mainIssue;
        Description = description;
    }

    public ReleaseVersion Version { get; private set; } = null!;
    public Platform Platform { get; private set; } = null!;
    public ReleaseStatus Status { get; private set; }
    public ReleaseCompleteDate CompleteDate { get; private set; } = null!;
    public ReleaseUpdateDate UpdateDate { get; private set; } = null!;
    public ReleaseDescription Description { get; private set; } = null!;
    public Issue MainIssue { get; private set; } = null!;

    public ErrorOr<Updated> ChangeMainIssue(Issue mainIssue, DateTime currentDateTime)
    {
        MainIssue = mainIssue;
        ChangeUpdateDate(currentDateTime);
        return Result.Updated;
    }

    public ErrorOr<Updated> ChangeDescription(ReleaseDescription description, DateTime currentDateTime)
    {
        Description = description;
        ChangeUpdateDate(currentDateTime);
        return Result.Updated;
    }

    public ErrorOr<Updated> ChangeVersion(ReleaseVersion version, DateTime currentDateTime)
    {
        if (version <= Version)
            return Errors.Release.VersionMustBeGreaterThanCurrent;
        Version = version;
        ChangeUpdateDate(currentDateTime);
        return Result.Updated;
    }

    public ErrorOr<Updated> ChangeCompleteDate(ReleaseCompleteDate completeDate, DateTime currentDateTime)
    {
        if (completeDate <= CompleteDate)
            return Errors.Release.CompleteDateMustBeGreaterThanCurrent;
        CompleteDate = completeDate;
        ChangeUpdateDate(currentDateTime);
        return Result.Updated;
    }

    public ErrorOr<Updated> ChangePlatform(Platform platform, DateTime currentDateTime)
    {
        Platform = platform;
        ChangeUpdateDate(currentDateTime);
        return Result.Updated;
    }

    public ErrorOr<Updated> ChangeStatus(ReleaseStatus status, DateTime currentDateTime)
    {
        Status = status;
        ChangeUpdateDate(currentDateTime);
        return Result.Updated;
    }

    private void ChangeUpdateDate(DateTime currentDateTime)
    {
        UpdateDate = ReleaseUpdateDate.Create(currentDateTime);
    }
}
