using ErrorOr;
using Mari.Application.Common.Interfaces.Persistence;
using Mari.Application.Common.Specifications;
using Mari.Application.Releases.Dto;
using Mari.Application.Releases.Results;
using MediatR;

namespace Mari.Application.Releases.Queries.GetAllPlatforms;

public class GetAllPlatformsQueryHandler : IRequestHandler<GetAllPlatformsQuery, ErrorOr<IEnumerable<PlatformResult>>>
{
    private readonly IReleaseRepository _releaseRepository;

    public GetAllPlatformsQueryHandler(IReleaseRepository releaseRepository)
    {
        _releaseRepository = releaseRepository;
    }

    public async Task<ErrorOr<IEnumerable<PlatformResult>>> Handle(GetAllPlatformsQuery request, CancellationToken token)
    {
        var platforms = _releaseRepository.GetAllPlatforms();
        var result = new List<PlatformResult>();

        await foreach (var platform in platforms)
        {
            var platformSpec = ReleaseSpecs.PlatformIn(platform);
            var version = await _releaseRepository.GetMaxVersion(platformSpec, token);
            result.Add(new PlatformResult(platform.Name, ReleaseVersionDto.FromVersion(version)));
        }

        return result;
    }
}
