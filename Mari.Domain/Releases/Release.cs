using ErrorOr;
using Mari.Domain.Common.Models;
using Mari.Domain.Releases.Entities;
using Mari.Domain.Releases.Enums;
using Mari.Domain.Releases.ValueObjects;
using Mari.Domain.Common;

namespace Mari.Domain.Releases;

public class Release : AggregateRoot<ReleaseId>
{
    public static ErrorOr<Release> Create(
        Issue? mainIssue,
        Platform? platform,
        ReleaseCompleteDate? completeDate,
        ReleaseStatus? status = null,
        ReleaseDescription? description = null,
        ReleaseVersion? version = null)
    {
        if (status is not ReleaseStatus.Draft and not ReleaseStatus.Planning)
            return Errors.Release.NewReleaseStatusMustBeDraftOrPlanning;

        var release = new Release(
            mainIssue: mainIssue,
            platform: platform,
            completeDate: completeDate,
            updateDate: ReleaseUpdateDate.Default,
            status: status ?? ReleaseStatus.Draft,
            description: description ?? ReleaseDescription.Default,
            version: version ?? ReleaseVersion.MinValue
        );

        var result = release.CheckDraftStatus();
        if (result.IsError) return result.Errors;
        return release;
    }

    private Release()
    {
    }

    private Release(
        Issue? mainIssue,
        ReleaseVersion version,
        Platform? platform,
        ReleaseCompleteDate? completeDate,
        ReleaseUpdateDate updateDate,
        ReleaseStatus status,
        ReleaseDescription description)
    {
        Version = version;
        Platform = platform!;
        Status = status;
        CompleteDate = completeDate!;
        UpdateDate = updateDate;
        MainIssue = mainIssue!;
        Description = description;
    }

    public ReleaseVersion Version { get; private set; } = null!;
    public Platform Platform { get; private set; } = null!;
    public ReleaseStatus Status { get; private set; }
    public ReleaseCompleteDate CompleteDate { get; private set; } = null!;
    public ReleaseUpdateDate UpdateDate { get; private set; } = null!;
    public ReleaseDescription Description { get; private set; } = null!;
    public Issue MainIssue { get; private set; } = null!;

    public bool IsReadOnly => Status is ReleaseStatus.Complete;

    public ErrorOr<Updated> ChangeMainIssue(Issue mainIssue, DateTime currentDateTime)
    {
        if (IsReadOnly) return Errors.Release.ReleaseIsReadOnly;
        MainIssue = mainIssue;
        return ChangeUpdateDate(currentDateTime);
    }

    public ErrorOr<Updated> ChangeDescription(ReleaseDescription description, DateTime currentDateTime)
    {
        if (IsReadOnly) return Errors.Release.ReleaseIsReadOnly;
        Description = description;
        return ChangeUpdateDate(currentDateTime);
    }

    public ErrorOr<Updated> ChangeVersion(ReleaseVersion version, DateTime currentDateTime)
    {
        if (IsReadOnly) return Errors.Release.ReleaseIsReadOnly;
        if (version <= Version)
            return Errors.Release.VersionMustBeGreaterThanCurrent;
        Version = version;
        return ChangeUpdateDate(currentDateTime);
    }

    public ErrorOr<Updated> ChangeCompleteDate(ReleaseCompleteDate completeDate, DateTime currentDateTime)
    {
        if (IsReadOnly) return Errors.Release.ReleaseIsReadOnly;
        if ((DateTime)completeDate <= (DateTime)CompleteDate)
            return Errors.Release.CompleteDateMustBeGreaterThanCurrent;
        CompleteDate = completeDate;
        return ChangeUpdateDate(currentDateTime);
    }

    public ErrorOr<Updated> ChangePlatform(Platform platform, DateTime currentDateTime)
    {
        if (IsReadOnly) return Errors.Release.ReleaseIsReadOnly;
        Platform = platform;
        return ChangeUpdateDate(currentDateTime);
    }

    public ErrorOr<Updated> ChangeStatus(ReleaseStatus status, DateTime currentDateTime)
    {
        if (IsReadOnly) return Errors.Release.ReleaseIsReadOnly;
        var prevStatus = Status;
        Status = status;
        var result = CheckDraftStatus();
        if (result.IsError)
        {
            Status = prevStatus;
            return result.Errors;
        }
        return ChangeUpdateDate(currentDateTime);
    }

    public ErrorOr<Success> CreateFromDraft()
    {
        if (Status != ReleaseStatus.Draft)
            return Errors.Release.ReleaseMustBeDraft;

        Status = ReleaseStatus.Planning;
        return Result.Success;
    }

    private ErrorOr<Updated> ChangeUpdateDate(DateTime currentDateTime)
    {
        UpdateDate = ReleaseUpdateDate.Create(currentDateTime);
        return Result.Updated;
    }

    private ErrorOr<Success> CheckDraftStatus()
    {
        if (Status == ReleaseStatus.Draft) return Result.Success;
        if (Platform is null || CompleteDate is null || MainIssue is null)
            return Errors.Release.NonDraftReleaseFieldsCannotBeNull;
        return Result.Success;
    }
}
