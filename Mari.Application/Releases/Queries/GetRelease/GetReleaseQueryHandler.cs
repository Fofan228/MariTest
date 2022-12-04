using ErrorOr;
using Mari.Application.Common.Interfaces.Persistence;
using Mari.Application.Releases.Results;
using MediatR;
using Mari.Domain.Common;

namespace Mari.Application.Releases.Queries.GetRelease;

internal class GetReleaseQueryHandler : IRequestHandler<GetReleaseQuery, ErrorOr<ReleaseResult>>
{
    private readonly IReleaseRepository _releaseRepository;

    public GetReleaseQueryHandler(IReleaseRepository releaseRepository)
    {
        _releaseRepository = releaseRepository;
    }

    public async Task<ErrorOr<ReleaseResult>> Handle(GetReleaseQuery request, CancellationToken cancellationToken)
    {
        var release = await _releaseRepository.GetById(request.Id, cancellationToken);
        if (release is null) return Errors.Release.ReleaseNotFound;
        return ReleaseResult.FromRelease(release);
    }
}
