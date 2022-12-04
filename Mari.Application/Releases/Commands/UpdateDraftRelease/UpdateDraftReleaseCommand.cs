using ErrorOr;
using Mari.Domain.Releases.Enums;
using Mari.Domain.Releases.ValueObjects;
using MediatR;

namespace Mari.Application.Releases.Commands.UpdateDraftRelease;

public record UpdateDraftReleaseCommand : IRequest<ErrorOr<Updated>>
{
    public UpdateDraftReleaseCommand(
        Guid id,
        int? versionMajor,
        int? versionMinor,
        int? versionPatch,
        string? platformName,
        DateTime? completeDate,
        string? mainIssue,
        string? description)
    {
        Id = ReleaseId.Create(id);

        if (versionMajor is not null && versionMinor is not null && versionPatch is not null)
            Version = ReleaseVersion.Create(versionMajor.Value, versionMinor.Value, versionPatch.Value);

        if (platformName is not null)
            PlatformName = PlatformName.Create(platformName);

        if (completeDate is not null)
            CompleteDate = ReleaseCompleteDate.Create(completeDate.Value);

        if (mainIssue is not null)
            MainIssue = Issue.Create(mainIssue);

        if (description is not null)
            Description = ReleaseDescription.Create(description);
    }

    public ReleaseId Id { get; }
    public ReleaseVersion? Version { get; }
    public PlatformName? PlatformName { get; }
    public ReleaseCompleteDate? CompleteDate { get; }
    public Issue? MainIssue { get; }
    public ReleaseDescription? Description { get; }
}
