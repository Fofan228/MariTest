using ErrorOr;
using Mari.Domain.Releases.ValueObjects;
using MediatR;

namespace Mari.Application.Releases.Commands.CreateDraftRelease;

public record CreateDraftReleaseCommand : IRequest<ErrorOr<Created>>
{
    public CreateDraftReleaseCommand(
        string? mainIssue,
        DateTime? completeDate,
        string? platformName,
        int? versionMajor,
        int? versionMinor,
        int? versionPatch,
        string? description)
    {
        if (mainIssue is not null)
            MainIssue = Issue.Create(mainIssue);

        if (completeDate is not null)
            CompleteDate = ReleaseCompleteDate.Create(completeDate.Value);

        if (platformName is not null)
            PlatformName = PlatformName.Create(platformName);

        Version = ReleaseVersion.Create(
            versionMajor ?? ReleaseVersion.MinMajor,
            versionMinor ?? ReleaseVersion.MinMinor,
            versionPatch ?? ReleaseVersion.MinPatch);

        if (description is not null)
            Description = ReleaseDescription.Create(description);
    }

    public Issue? MainIssue { get; }
    public ReleaseCompleteDate? CompleteDate { get; }
    public PlatformName? PlatformName { get; }
    public ReleaseVersion? Version { get; }
    public ReleaseDescription? Description { get; }
}
