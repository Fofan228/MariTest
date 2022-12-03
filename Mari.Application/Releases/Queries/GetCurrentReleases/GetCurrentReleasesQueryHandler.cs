using ErrorOr;
using Mari.Application.Common.Interfaces.Persistence;
using Mari.Application.Releases.Results;
using MediatR;

namespace Mari.Application.Releases.Queries.GetCurrentReleases;

internal class GetCurrentReleasesQueryHandler : IRequestHandler<GetCurrentReleasesQuery, ErrorOr<IEnumerable<ReleaseResult>>>
{
    private readonly IReleaseRepository _releaseRepository;

    public GetCurrentReleasesQueryHandler(IReleaseRepository releaseRepository)
    {
        _releaseRepository = releaseRepository;
    }

    public async Task<ErrorOr<IEnumerable<ReleaseResult>>> Handle(GetCurrentReleasesQuery request, CancellationToken token)
    {
        var currentReleases = _releaseRepository.GetCurrentReleases(request.Range);
        return await currentReleases.Select(r => ReleaseResult.FromRelease(r))
            .ToListAsync();
    }
}
