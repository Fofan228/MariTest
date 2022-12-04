using ErrorOr;
using Mari.Application.Common.Interfaces.Persistence;
using Mari.Application.Common.Specifications;
using Mari.Application.Releases.Results;
using Mari.Domain.Releases.Enums;
using MediatR;

namespace Mari.Application.Releases.Queries.GetPlannedReleases;

internal class GetPlannedReleasesQueryHandler : IRequestHandler<GetPlannedReleasesQuery, ErrorOr<IEnumerable<ReleaseResult>>>
{
    private readonly IReleaseRepository _releaseRepository;

    public GetPlannedReleasesQueryHandler(IReleaseRepository releaseRepository)
    {
        _releaseRepository = releaseRepository;
    }

    public async Task<ErrorOr<IEnumerable<ReleaseResult>>> Handle(GetPlannedReleasesQuery request, CancellationToken cancellationToken)
    {
        var spec = ReleaseSpecs.StatusIn(ReleaseStatus.Planning);
        return await _releaseRepository.FindMany(spec, request.Range)
            .Select(release => ReleaseResult.FromRelease(release))
            .ToListAsync(cancellationToken);
    }
}
