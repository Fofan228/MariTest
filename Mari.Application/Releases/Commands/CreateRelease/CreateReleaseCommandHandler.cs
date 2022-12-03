using ErrorOr;
using Mari.Application.Common.Interfaces.Persistence;
using Mari.Domain.Releases;
using Mari.Domain.Releases.Entities;
using Mari.Domain.Releases.Enums;
using MediatR;

namespace Mari.Application.Releases.Commands.CreateRelease;

internal class CreateReleaseCommandHandler : IRequestHandler<CreateReleaseCommand, ErrorOr<Created>>
{
    private readonly IReleaseRepository _releaseRepository;

    public CreateReleaseCommandHandler(IReleaseRepository releaseRepository)
    {
        _releaseRepository = releaseRepository;
    }

    public async Task<ErrorOr<Created>> Handle(CreateReleaseCommand request, CancellationToken cancellationToken)
    {
        var platformCreateResult = Platform.Create(request.PlatformName);

        if (platformCreateResult.IsError) return platformCreateResult.Errors;

        var releaseCreateResult = Release.Create(
            mainIssue: request.MainIssue,
            platform: platformCreateResult.Value,
            completeDate: request.CompleteDate,
            version: request.Version,
            description: request.Description,
            status: ReleaseStatus.Planning);

        if (releaseCreateResult.IsError) return releaseCreateResult.Errors;

        await _releaseRepository.Insert(releaseCreateResult.Value, cancellationToken);
        return Result.Created;
    }
}